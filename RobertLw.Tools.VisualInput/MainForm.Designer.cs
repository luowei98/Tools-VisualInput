using System.Windows.Forms;
using RobertLw.Windows.WinFormEx;


namespace RobertLw.Tools.VisualInput
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.buttonAddKeyboard = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddMouse = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.clCheckbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxRecord = new RobertLw.Windows.WinFormEx.HotkeyBox();
            this.textBoxStartStop = new RobertLw.Windows.WinFormEx.HotkeyBox();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            // 
            // propertyGrid
            // 
            this.propertyGrid.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(310, 62);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid.Size = new System.Drawing.Size(211, 220);
            this.propertyGrid.TabIndex = 3;
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            this.propertyGrid.SelectedObjectsChanged += new System.EventHandler(this.propertyGrid_SelectedObjectsChanged);
            this.propertyGrid.Validating += new System.ComponentModel.CancelEventHandler(this.propertyGrid_Validating);
            // 
            // buttonAddKeyboard
            // 
            this.buttonAddKeyboard.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddKeyboard.Location = new System.Drawing.Point(138, 290);
            this.buttonAddKeyboard.Name = "buttonAddKeyboard";
            this.buttonAddKeyboard.Size = new System.Drawing.Size(120, 31);
            this.buttonAddKeyboard.TabIndex = 5;
            this.buttonAddKeyboard.Text = "添加键盘动作(&K)";
            this.buttonAddKeyboard.UseVisualStyleBackColor = true;
            this.buttonAddKeyboard.Click += new System.EventHandler(this.buttonAddKeyboard_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDelete.Location = new System.Drawing.Point(264, 290);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(120, 31);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "删除(&D)";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "开始/结束键：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "记录位置键：";
            // 
            // buttonAddMouse
            // 
            this.buttonAddMouse.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddMouse.Location = new System.Drawing.Point(12, 290);
            this.buttonAddMouse.Name = "buttonAddMouse";
            this.buttonAddMouse.Size = new System.Drawing.Size(120, 31);
            this.buttonAddMouse.TabIndex = 4;
            this.buttonAddMouse.Text = "添加鼠标动作(&M)";
            this.buttonAddMouse.UseVisualStyleBackColor = true;
            this.buttonAddMouse.Click += new System.EventHandler(this.buttonAddMouse_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonDown.Image")));
            this.buttonDown.Location = new System.Drawing.Point(272, 105);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(32, 37);
            this.buttonDown.TabIndex = 2;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.Location = new System.Drawing.Point(272, 62);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(32, 37);
            this.buttonUp.TabIndex = 1;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clCheckbox,
            this.clName});
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(12, 62);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(253, 220);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // clCheckbox
            // 
            this.clCheckbox.Text = "";
            this.clCheckbox.Width = 30;
            // 
            // clName
            // 
            this.clName.Text = "名称";
            this.clName.Width = 200;
            // 
            // textBoxRecord
            // 
            this.textBoxRecord.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRecord.Location = new System.Drawing.Point(401, 20);
            this.textBoxRecord.Name = "textBoxRecord";
            this.textBoxRecord.ShortcutsEnabled = false;
            this.textBoxRecord.Size = new System.Drawing.Size(120, 23);
            this.textBoxRecord.TabIndex = 8;
            this.textBoxRecord.Value = null;
            // 
            // textBoxStartStop
            // 
            this.textBoxStartStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxStartStop.Location = new System.Drawing.Point(128, 20);
            this.textBoxStartStop.Name = "textBoxStartStop";
            this.textBoxStartStop.ShortcutsEnabled = false;
            this.textBoxStartStop.Size = new System.Drawing.Size(120, 23);
            this.textBoxStartStop.TabIndex = 7;
            this.textBoxStartStop.Value = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 337);
            this.Controls.Add(this.buttonAddMouse);
            this.Controls.Add(this.textBoxRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxStartStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAddKeyboard);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.listView);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visual Input";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button buttonAddKeyboard;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Label label1;
        private RobertLw.Windows.WinFormEx.HotkeyBox textBoxStartStop;
        private RobertLw.Windows.WinFormEx.HotkeyBox textBoxRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader clName;
        private System.Windows.Forms.Button buttonAddMouse;
        private ColumnHeader clCheckbox;
    }
}

