#region File Descrption

// /////////////////////////////////////////////////////////////////////////////
// 
// Project: RobertLw.Tools.VisualInput.RobertLw.Tools.VisualInput
// File:    KeyboardActionItem.cs
// 
// Create by Robert.L at 2012/11/22 11:13
// 
// /////////////////////////////////////////////////////////////////////////////

#endregion

using System.ComponentModel;
using RobertLw.Class.Extensions;


namespace RobertLw.Tools.VisualInput.Model
{
    [DefaultProperty("Characters")]
    public class KeyboardActionItem : ActionItem
    {
        public KeyboardActionItem(ActionItem action = null)
            : base(ActionType.Keyboard)
        {
            Name = "键盘动作";

            Copy(action);
        }

        [OrderedDisplayName(7, "字符")]
        public string Characters { get; set; }
    }
}