using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using RobertLw.Class.Extensions;
using RobertLw.Tools.VisualInput.FormModel;
using RobertLw.Tools.VisualInput.Model;
using RobertLw.WinOS;


namespace RobertLw.Tools.VisualInput
{
    public partial class MainForm : Form
    {
        #region 私有变量

        private readonly MainFormModel model;

        private GlobalHotkey hotkey;
        private int hotkeyIdRecord;
        private int hotkeyIdStartStop;
        private int repeatTimes = 1;
        private bool running;

        #endregion

        #region 属性

        private int actionIndex;

        public ActionItem currentAction
        {
            get { return model.Actions[actionIndex].Item1; }
        }

        #endregion

        #region 窗体事件

        public MainForm()
        {
            InitializeComponent();

            model = new MainFormModel();
            model.Load();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 热键定义
            textBoxStartStop.Value = model.StartStopKey;
            textBoxRecord.Value = model.RecordKey;

            hotkey = new GlobalHotkey(Handle);
            hotkeyIdStartStop = hotkey.RegisterHotkey(textBoxStartStop.Value.Key, textBoxStartStop.Value.Modifiers);
            hotkeyIdRecord = hotkey.RegisterHotkey(textBoxRecord.Value.Key, textBoxRecord.Value.Modifiers);
            hotkey.OnHotkey += OnHotkey;

            // 动作列表
            SetListView();
            if (listView.Items.Count > 0)
            {
                listView.Items[0].Selected = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            hotkey.UnregisterHotkeys();

            model.Save();
        }

        #endregion

        #region 控件事件

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (!running) return;

            listView.Items[actionIndex].Selected = true;

            if (currentAction.Type == ActionType.Mouse)
            {
                var act = (MouseActionItem) currentAction;
                MouseCircleVisible v = act.Hide == MouseActionItem.BoolEnum.No
                                           ? MouseCircleVisible.Show
                                           : MouseCircleVisible.Hide;
                if (act.Location.HasValue)
                {
                    MouseHelper.AutoClick(act.Location.Value.X, act.Location.Value.Y, v);
                }
                else
                {
                    MouseHelper.AutoClick(v);
                }
            }
            else if (currentAction.Type == ActionType.Keyboard)
            {
                var act = (KeyboardActionItem) currentAction;
                if (!string.IsNullOrEmpty(act.Characters))
                {
                    foreach (char c in act.Characters)
                    {
                        KeyboardHelper.AutoInput(c);
                        Thread.Sleep(100);
                    }
                }
            }

            if (repeatTimes < currentAction.RepeatTime)
            {
                repeatTimes++;
                timer.Interval = currentAction.Interval;
                timer.Start();
            }
            else
            {
                repeatTimes = 1;
                timer.Interval = currentAction.Wait;
                setNextAction();
                timer.Start();
            }
        }

        private void OnHotkey(int hotkeyId)
        {
            if (hotkeyId == hotkeyIdStartStop)
            {
                running = !running;

                if (running)
                {
                    if (model.Actions.Count == 0) return;
                    repeatTimes = 1;

                    if (!timer.Enabled)
                    {
//                        WindowState = FormWindowState.Minimized;
                        timer.Interval = 100;
                        timer.Start();
                    }

                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(800, "开始自动点击", "按" + textBoxStartStop.Value + "停止", ToolTipIcon.Info);

//                    Visible = false;
                }
                else
                {
                    timer.Stop();

                    notifyIcon.Visible = false;

                    Visible = true;
                    WindowState = FormWindowState.Normal;

                    Activate();
                }
            }
            else if (hotkeyId == hotkeyIdRecord)
            {
                if (!IsFoucsedLocationProperty()) return;

                Point pos = MouseHelper.GetPosition();


                var act = (MouseActionItem) selectedAction();
                act.Location = pos;

                //var loc = propertyGrid.SelectedGridItem.PropertyDescriptor;
                //if (loc == null) return;
                //loc.SetValue(propertyGrid.SelectedObject, pos);

                propertyGrid.Refresh();
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0) return;

            string name = listView.SelectedItems[0].SubItems[1].Text;
            Tuple<ActionItem, bool> item = model.Actions.Find(i => i.Item1.Name == name);
            if (item == null) return;

            ActionItem act = item.Item1;
            propertyGrid.SelectedObject = act;

            actionIndex = listView.SelectedItems[0].Index;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (actionIndex <= 0) return;

            Tuple<ActionItem, bool> act = model.Actions[actionIndex];
            model.Actions.Remove(act);
            model.Actions.Insert(actionIndex - 1, act);
            actionIndex--;

            SetListView();
            listView.Items[actionIndex].Selected = true;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (actionIndex >= model.Actions.Count - 1) return;

            Tuple<ActionItem, bool> act = model.Actions[actionIndex];
            model.Actions.Remove(act);
            model.Actions.Insert(actionIndex + 1, act);
            actionIndex++;

            SetListView();
            listView.Items[actionIndex].Selected = true;
        }

        private void buttonAddMouse_Click(object sender, EventArgs e)
        {
            var act = new MouseActionItem();

            int n = model.Actions.Count(a => a.Item1.Type == ActionType.Mouse);
            act.Name += n.ToString();

            model.Actions.Add(new Tuple<ActionItem, bool>(act, true));

            SetListView();
            listView.Items[listView.Items.Count - 1].Selected = true;
        }

        private void buttonAddKeyboard_Click(object sender, EventArgs e)
        {
            var act = new KeyboardActionItem();

            int n = model.Actions.Count(a => a.Item1.Type == ActionType.Keyboard);
            act.Name += n.ToString();

            model.Actions.Add(new Tuple<ActionItem, bool>(act, true));

            SetListView();

            listView.Items[listView.Items.Count - 1].Selected = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count == 0) return;

            model.Actions.RemoveAt(actionIndex);

            SetListView();

            int i = actionIndex == 0 ? 0 : actionIndex + 1;
            if (i > model.Actions.Count - 1) i = model.Actions.Count - 1;
            listView.Items[i].Selected = true;
        }

        #endregion

        #region 私有函数

        private void SetListView()
        {
            listView.Items.Clear();
            foreach (var act in model.Actions)
            {
                var lvi = new ListViewItem();
                lvi.SubItems.Add(act.Item1.ToString());
                lvi.Checked = act.Item2;
                listView.Items.Add(lvi);
            }
        }

        private void setNextAction()
        {
            do
            {
                actionIndex = ++actionIndex%model.Actions.Count;
            } while (!listView.Items[actionIndex].Checked);
        }

        private ActionItem selectedAction()
        {
            int idx = listView.SelectedItems[0].Index;
            return model.Actions[idx].Item1;
        }

        private bool IsFoucsedLocationProperty()
        {
            bool selected = propertyGrid.Controls
                .Cast<Control>()
                .Aggregate(false, (current, c) => current || c.Focused);
            if (!selected) return false;
            GridItem item = propertyGrid.SelectedGridItem;

            string locationName = ReflectionEx.GetPropertyDisplayName<MouseActionItem>(i => i.Location);
            return item != null && item.Label != null && item.Label.Equals(locationName);
        }

        #endregion

        private void propertyGrid_Validating(object sender, CancelEventArgs e)
        {
            //int value = ((ActionItem)propertyGrid.SelectedObject).RepeatTime;
            //PropertyDescriptor descriptor = TypeDescriptor.GetProperties(propertyGrid.SelectedObject.GetType())["Interval"];
            //var attr = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            //FieldInfo isReadOnly = attr.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            //if (isReadOnly==null) return;
            //isReadOnly.SetValue(attr, value==0);
            ////propertyGrid.SelectedObject = propertyGrid.SelectedObject;
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
        }

        private void propertyGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            var act = (ActionItem) propertyGrid.SelectedObject;
            act.SetEditable();
        }
    }
}