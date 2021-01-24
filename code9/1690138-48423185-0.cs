    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication9
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("NAME", typeof(string));
                dt.Rows.Add(new object[] {"FR", "APPLE"});
                dt.Rows.Add(new object[] {"FR", "BANANA"});
                dt.Rows.Add(new object[] {"TR", "FISTIK"});
                dt.Rows.Add(new object[] {"GR", "ENGINE"});
                dt.Rows.Add(new object[] {"GR", "TANK"});
                populateTreeview(dt);
                treeView1.ExpandAll();
            }
            //Open the XML file, and start to populate the treeview
            private void populateTreeview(DataTable dt)
            {
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<string>("Type"));
                treeView1.Nodes.Clear();
                foreach(var group in groups)
                {
                    TreeNode node = treeView1.Nodes.Add(group.Key);
                    foreach(string name in group.Select(x => x.Field<string>("NAME")))
                    {
                        node.Nodes.Add(name);
                    }
                }
            }
        }
    }
