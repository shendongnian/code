    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyControlDesigner))]
    public class MyControl : Control
    {
        public string[] Lines
        {
            get
            {
                return this.Text.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            }
            set
            {
                if (value != null)
                    this.Text = string.Join(Environment.NewLine, value);
            }
        }
    }
<!---->
    public class MyControlDesigner : ControlDesigner
    {
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                var list = new DesignerActionListCollection();
                list.Add(new MyControlActionList(this));
                return list;
            }
        }
    }
