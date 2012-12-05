#region File Descrption

// /////////////////////////////////////////////////////////////////////////////
// 
// Project: RobertLw.Tools.VisualInput.RobertLw.Tools.VisualInput
// File:    MainFormModel.cs
// 
// Create by Robert.L at 2012/11/26 14:40
// 
// /////////////////////////////////////////////////////////////////////////////

#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using RobertLw.Class.Extensions;
using RobertLw.Tools.VisualInput.Model;
using RobertLw.Windows.WinFormEx;


namespace RobertLw.Tools.VisualInput.FormModel
{
    public class MainFormModel
    {
        private readonly string path;

        public MainFormModel()
        {
            path = Path.Combine(Application.StartupPath, "default.config");
        }


        public HotkeyBox.HotkeyValue StartStopKey { get; set; }
        public HotkeyBox.HotkeyValue RecordKey { get; set; }
        public List<Tuple<ActionItem, bool>> Actions { get; set; }


        private void createDefaultConfig()
        {
            StartStopKey = new HotkeyBox.HotkeyValue {Key = Keys.F5};
            RecordKey = new HotkeyBox.HotkeyValue {Key = Keys.F9};
            Actions = new List<Tuple<ActionItem, bool>>();

            Save();
        }

        public void Save()
        {
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XComment("Visual Input Config File"),
                new XElement("Configuration",
                             new XAttribute("StartStopKey", StartStopKey),
                             new XAttribute("RecordKey", RecordKey),
                             Actions.Select(a =>
                                            new XElement("ActionList",
                                                         new XAttribute("Enable", a.Item2),
                                                         action2Element(a.Item1)
                                                )
                                 )
                    )
                );

            doc.Save(path, SaveOptions.None);
        }

        public void Load()
        {
            if (!File.Exists(path))
            {
                createDefaultConfig();
                return;
            }

            XDocument doc = XDocument.Load(path);
            IEnumerable<MainFormModel> configs =
                from m in doc.Descendants("Configuration")
                let startStopKeyAttr = m.Attribute("StartStopKey")
                let recordAttr = m.Attribute("RecordKey")
                select new MainFormModel
                       {
                           StartStopKey =
                               new HotkeyBox.HotkeyValue(startStopKeyAttr == null
                                                             ? ""
                                                             : startStopKeyAttr.Value),
                           RecordKey =
                               new HotkeyBox.HotkeyValue(recordAttr == null
                                                             ? ""
                                                             : recordAttr.Value),
                           Actions = (from al in m.Elements("ActionList")
                                      let action = al.Element("Action")
                                      let enable = al.Attribute("Enable")
                                      select new Tuple<ActionItem, bool>(
                                          element2Action(action),
                                          enable != null &&
                                          enable.Value.ToLower().Equals("true")
                                          ))
                               .ToList()
                       };

            MainFormModel config = configs.FirstOrDefault();
            if (config == null) return;
            StartStopKey = config.StartStopKey;
            RecordKey = config.RecordKey;
            Actions = config.Actions;
        }

        private static ActionItem element2Action(XElement action)
        {
            XAttribute t = action.Attribute("Type");
            if (t != null)
            {
                switch (t.Value)
                {
                    case "Mouse":
                        return new MouseActionItem(xelement2Action(action, ActionType.Mouse))
                               {
                                   Location = attribute2Point(action.Attribute("Location")),
                                   Hide = attribute2BoolEnum(action.Attribute("Hide")),
                               };
                    case "Keyboard":
                        XAttribute charactersAttr = action.Attribute("Characters");
                        string characters = "";
                        if (charactersAttr != null)
                            characters = charactersAttr.Value;
                        return new KeyboardActionItem(xelement2Action(action, ActionType.Keyboard))
                               {
                                   Characters = characters
                               };
                }
            }
            return new MouseActionItem();
        }

        private static Point? attribute2Point(XAttribute location)
        {
            if (location == null) return null;

            string l = location.Value;
            if (string.IsNullOrWhiteSpace(l)) return null;

            string x = l.Substring(l.IndexOf("=") + 1, l.IndexOf(",") - l.IndexOf("=") - 1);
            string y = l.Substring(l.LastIndexOf("=") + 1, l.LastIndexOf("}") - l.LastIndexOf("=") - 1);
            int xi, yi;
            if (int.TryParse(x, out xi) && int.TryParse(y, out yi))
            {
                return new Point(xi, yi);
            }

            return null;
        }

        private static MouseActionItem.BoolEnum attribute2BoolEnum(XAttribute hide)
        {
            if (hide == null) return MouseActionItem.BoolEnum.No;

            string h = hide.Value;
            if (string.IsNullOrWhiteSpace(h)) return MouseActionItem.BoolEnum.No;

            object value = EnumEx.GetEnumValue(typeof (MouseActionItem.BoolEnum), h);
            if (value is string) return MouseActionItem.BoolEnum.No;

            return (MouseActionItem.BoolEnum) value;
        }

        private static ActionItem xelement2Action(XElement action, ActionType type)
        {
            var act = new ActionItem(type);

            XAttribute name = action.Attribute("Name");
            if (name != null)
            {
                act.Name = name.Value;
            }

            XAttribute repeat = action.Attribute("RepeatTime");
            if (repeat != null)
            {
                act.RepeatTime = str2Int(repeat.Value);
            }

            XAttribute interval = action.Attribute("Interval");
            if (interval != null)
            {
                act.Interval = str2Int(interval.Value);
            }

            XAttribute wait = action.Attribute("Wait");
            if (wait != null)
            {
                act.Wait = str2Int(wait.Value);
            }

            return act;
        }

        private static XElement action2Element(ActionItem action)
        {
            var e = new XElement("Action");

            foreach (var i in action.GetType().GetProperties())
            {
                e.Add(new XAttribute(i.Name, i.GetValue(action, null) ?? ""));
            }

            return e;
        }

        private static int str2Int(string s)
        {
            int i;
            return int.TryParse(s, out i) ? i : 0;
        }
    }
}