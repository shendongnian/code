    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace TrimBlanksInDGV_45358146
    {
        public partial class Form1 : Form
        {
            public static string whatwasit = "";
            public Form1()
            {
    
                InitializeComponent();
                List<listitem> datasource = new List<listitem>();
                datasource.Add(new TrimBlanksInDGV_45358146.listitem { name = "name1", last = "last1" });
                datasource.Add(new TrimBlanksInDGV_45358146.listitem { name = "name2", last = "last2" });
                datasource.Add(new TrimBlanksInDGV_45358146.listitem { name = "name3", last = "last3" });
                datasource.Add(new TrimBlanksInDGV_45358146.listitem { name = "name4", last = "last4" });
                datasource.Add(new TrimBlanksInDGV_45358146.listitem { name = " ", last = "last5" });
                datasource.Add(new TrimBlanksInDGV_45358146.listitem { name = "", last = "last6" });
                dataGridView1.DataSource = datasource;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Trim() != "")
                    {
                        whatwasit = "not empty or \"\"";
                    }
                    else
                    {
                        whatwasit = "empty or \"\"";
                    }
                }
            }
        }
    
        public class listitem
        {
            public string name { get; set; }
            public string last { get; set; }
        }
    }
