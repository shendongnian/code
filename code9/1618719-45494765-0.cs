    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
    
            DataGridView dgv = new DataGridView();
            BindingList<dgvitem> itemsList = new BindingList<dgvitem>();
    
            public Form1()
            {
                InitializeComponent();
                InitializeTheDGV();
                itemsList.Add(new dgvitem { JustaTextField = "aksldjf sadfjasifuqw adsfasf" });
                itemsList.Add(new dgvitem { JustaTextField = "qwerioqu aisdfnvmz, oaa" });
            }
    
            private void InitializeTheDGV()
            {
                dgv.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
                dgv.DataSource = itemsList;
                dgv.AutoGenerateColumns = false;
                this.Controls.Add(dgv);
                dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "My col header", Name = "mycol1" });
                dgv.Columns.Add(new DataGridViewButtonColumn() { HeaderText = "click in this column", Name = "mycol2" });
                dgv.Columns["mycol1"].DataPropertyName = "JustaTextField";
                dgv.CellContentClick += Dgv_CellContentClick;
            }
    
            private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (!(sender is DataGridView))
                {
                    return;
                }
                dgv.Rows[e.RowIndex].Cells[1] = new DataGridViewTextBoxCell();
                dgv.Rows[e.RowIndex].Cells[1].Value = "put some text in here";
            }
        }
    
    
        public class dgvitem
        {
            public string JustaTextField { get; set; }
        }
    }
