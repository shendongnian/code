    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            DataGridView dgv = new DataGridView();
    
            public Form1()
            {
                InitializeComponent();
                initours();
    
                checkone();
            }
    
            private void checkone()
            {
                dgv.Rows[0].Cells[0].Value = true;//chekc the one in the first row
            }
    
            private void initours()
            {
                this.Controls.Add(dgv);
                dgv.Dock = DockStyle.Fill;
    
                dgv.AutoGenerateColumns = false;
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                dgv.Columns.Add(col);
                dgv.Rows.Add();
                dgv.Rows.Add();
                dgv.Rows.Add();
                dgv.Rows.Add();
            }
        }
    }
