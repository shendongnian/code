    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace DGVCellTypes_47599159
    {
        public partial class Form1 : Form
        {
    
            DataGridView dgv = new DataGridView();
            BindingList<dgventry> dgventries = new BindingList<dgventry>();
            public Form1()
            {
                InitializeComponent();
                InitOurStuff();
            }
    
            private void InitOurStuff()
            {
                this.Controls.Add(dgv);
                dgv.Dock = DockStyle.Top;
                dgv.DataSource = dgventries;
                dgv.CellMouseDown += Dgv_CellMouseDown;
                for (int i = 0; i < 10; i++)
                {
                    dgventries.Add(new dgventry { col1 = $"col1_{i}", col2 = $"col2_{i}", col3 = (i % 2) > 0 });
                }
            }
    
            private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
    
                if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
                {
                    //do something
                }
                else if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
                {
                    //do something
                }
                else if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewImageCell)
                {
                    //do something
                }
                else
                {
                    //do something
                }
            }
        }
    
    
        public class dgventry
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public bool col3 { get; set; }
    
        }
    }
