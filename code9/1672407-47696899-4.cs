    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DataGridViewToXML_47696565
    {
        public partial class Form2 : Form
        {
            BindingList<dgventry> dgvdata = new BindingList<dgventry>();
            DataGridView dgv = new DataGridView();
            Button btn = new Button();
    
    
            public Form2()
            {
                InitializeComponent();
                initOurStuff();
            }
    
            private void initOurStuff()
            {
                dgv.Dock = DockStyle.Top;
                dgv.DataSource = dgvdata;
                this.Controls.Add(dgv);
    
                for (int i = 0; i < 10; i++)
                {
                    dgvdata.Add(new dgventry { col1 = $"col1 row{i}", col2 = $"col2 row{i}", col3 = $"col3 row{i}" });
                }
    
                this.Controls.Add(btn);
                btn.Location = new Point(5, dgv.Location.Y + dgv.Height + 5);
                btn.Text = "Click me";
                btn.Click += Btn_Click; ;
            }
    
            private void Btn_Click(object sender, EventArgs e)
            {
    
    
                /*The DataSource connected to the DGV is not already a DataTable,
                 so I'll traverse the DataGridView and create my own DataTable out of it*/
                DataTable dt = new DataTable();//create the data table
                dt.TableName = "SD";//give it a name
                //create the appropriate number of columns
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    dt.Columns.Add(dgv.Columns[i].HeaderText);
                }
    
                //loop through each row of the DataGridView
                foreach (DataGridViewRow currentRow in dgv.Rows)
                {
                    dt.Rows.Add();
                    int runningCount = 0;
                    //loop trough each column of the row
                    foreach (DataGridViewCell item in currentRow.Cells)
                    {
                        dt.Rows[dt.Rows.Count - 1][runningCount] = item.FormattedValue;
                        runningCount++;
                    }
                }
    
                if (dt != null)
                {
                    dt.WriteXml(@"c:\temp\mynewxml.xml");
                }
    
            }
        }
    
    
        public class dgventry
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
        }
    }
