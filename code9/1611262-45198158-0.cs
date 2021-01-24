    using System;
    using System.Data;
    using System.Windows.Forms;
    namespace WindowsFormsApp5
    {
    public partial class Form1 : Form
    {
        private DataGridView oDg;
        public Form1()
        {
            InitializeComponent();
            CreateGrid();
            this.Shown += Form1_Shown;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            TestIt();
        }
        private void TestIt()
        {
            //works
            for (int i = 0;i < oDg.RowCount; i++)
            {
                for (int j = 0;j< oDg.ColumnCount; j++)
                {
                    oDg.Rows[i].Cells[j].Value = null; //this is important.
                    DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
                    c.Items.Add("On");
                    c.Items.Add("Off");
                    oDg.Rows[i].Cells[j] = c;  
                }
            }    
            //does not work
            //foreach (DataGridViewRow row in oDg.Rows)
            //{
            //    foreach (DataGridViewCell ce in row.Cells)
            //    {
            //        oDg.Rows[ce.RowIndex].Cells[ce.ColumnIndex].Value = null;
            //        DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
            //        c.Items.Add("On");
            //        c.Items.Add("Off");
            //        oDg.Rows[ce.RowIndex].Cells[ce.ColumnIndex] = c;
            //    }
            //}
        }
        private void CreateGrid()
        {
            oDg = new DataGridView();
            oDg.Width = 800;
            oDg.Height = 800;
            oDg.DataSource = CreateDataSource();
            this.Controls.Add(oDg);
        }
        private DataTable CreateDataSource()
        {
            DataTable oDt = new DataTable();
            for(int i = 0; i < 8; i++)
            {
                DataColumn col = new DataColumn(i.ToString(),typeof (String));
                oDt.Columns.Add(col);
            }
            for (int i = 0; i < 99; i++)
            {
                DataRow rw = oDt.NewRow();
                for (int j = 0;j < oDt.Columns.Count; j++)
                {
                    rw[j] = j.ToString();
                }
                oDt.Rows.Add(rw);
            }
            return oDt;
        }
    }
    }
