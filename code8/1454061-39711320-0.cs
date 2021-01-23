    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Age", typeof(int));
                dt.Rows.Add(new object[] { "John", 25 });
                dt.Rows.Add(new object[] { "Mary", 26 });
                dt.Rows.Add(new object[] { "Bill", 27 });
                dt.Rows.Add(new object[] { "Beth", 28 });
                dataGridView1.DataSource = dt;
                //reverse
                DataTable dt2 = new DataTable("NewTable");
                foreach (DataGridViewColumn column in  dataGridView1.Columns)
                {
                    dt2.Columns.Add(column.Name, column.ValueType);
                }
                //don't save last row of dattagridview which is the blank editable row
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    DataRow newRow = dt2.Rows.Add();
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        newRow[j] = row.Cells[j].Value;
                    }
                }
                dt2.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
            }
        }
    }
