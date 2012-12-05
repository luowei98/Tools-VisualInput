#region File Descrption

// /////////////////////////////////////////////////////////////////////////////
// 
// Project: RobertLw.Tools.VisualInput.RobertLw.Tools.VisualInput
// File:    ActionItem.cs
// 
// Create by Robert.L at 2012/11/15 19:16
// 
// /////////////////////////////////////////////////////////////////////////////

#endregion

using System.ComponentModel;
using System.Reflection;
using RobertLw.Class.Extensions;


namespace RobertLw.Tools.VisualInput.Model
{
    public class ActionItem
    {
        private int repeatTime;

        public ActionItem(ActionType type)
        {
            Type = type;
            Wait = 3000;

            RepeatTime = 2;
            Interval = 0;

            SetEditable();
        }

        [OrderedDisplayName(8, "名称")]
        public string Name { get; set; }

        [OrderedDisplayName(9, "类型")]
        public ActionType Type { get; private set; }

        [RefreshProperties(RefreshProperties.All)]
        [OrderedDisplayName(3, "重复次数")]
        public int RepeatTime
        {
            get { return repeatTime; }
            set
            {
                repeatTime = value;
                SetEditable();
            }
        }

        [OrderedDisplayName(2, "间隔时间")]
        [ReadOnly(true)]
        public int Interval { get; set; }

        [OrderedDisplayName(1, "等待时间")]
        public int Wait { get; set; }


        public void Copy(ActionItem action)
        {
            if (action == null) return;

            Name = action.Name;
            RepeatTime = action.RepeatTime;
            Interval = action.Interval;
            Wait = action.Wait;
        }

        public override string ToString()
        {
            return Name;
        }

        public void SetEditable()
        {
            PropertyDescriptor desc = TypeDescriptor.GetProperties(GetType())["Interval"];
            var attr = (ReadOnlyAttribute) desc.Attributes[typeof (ReadOnlyAttribute)];
            FieldInfo info = attr
                .GetType()
                .GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            if (info == null) return;

            bool isReadOnly = repeatTime == 0 || repeatTime == 1;
            if (isReadOnly) Interval = 0;
            info.SetValue(attr, isReadOnly);
        }
    }

    [TypeConverter(typeof (EnumDescConverter))]
    public enum ActionType
    {
        [Description("鼠标")] Mouse,
        [Description("键盘")] Keyboard,
    }
}