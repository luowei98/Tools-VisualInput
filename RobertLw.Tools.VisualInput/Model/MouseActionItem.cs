#region File Descrption

// /////////////////////////////////////////////////////////////////////////////
// 
// Project: RobertLw.Tools.VisualInput.RobertLw.Tools.VisualInput
// File:    MouseActionItem.cs
// 
// Create by Robert.L at 2012/11/15 19:20
// 
// /////////////////////////////////////////////////////////////////////////////

#endregion

using System.ComponentModel;
using System.Drawing;
using RobertLw.Class.Extensions;


namespace RobertLw.Tools.VisualInput.Model
{
    [DefaultProperty("Location")]
    public class MouseActionItem : ActionItem
    {
        #region BoolEnum enum

        [TypeConverter(typeof (EnumDescConverter))]
        public enum BoolEnum
        {
            [Description("否")] No,
            [Description("是")] Yes,
        }

        #endregion

        public MouseActionItem(ActionItem action = null)
            : base(ActionType.Mouse)
        {
            Name = "鼠标动作";

            Copy(action);
        }

        [OrderedDisplayName(7, "位置")]
        public Point? Location { get; set; }

        [OrderedDisplayName(6, "隐藏")]
        public BoolEnum Hide { get; set; }
    }
}