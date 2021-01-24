    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
    
            DataGridView dgv = new DataGridView();
            BindingList<dgvitem> itemsList = new BindingList<dgvitem>();
            bool SendAsRow = true;//just a variable to trigger the proper method in 'Dgv_CellContentClick'
            Button independantButton = new Button();
    
            public Form1()
            {
                InitializeComponent();
                InitializeTheDGV();
                AddTheButton();
                itemsList.Add(new dgvitem { JustaTextField = "aksldjf sadfjasifuqw adsfasf" });
                itemsList.Add(new dgvitem { JustaTextField = "qwerioqu aisdfnvmz, oaa"});
            }
    
            private void InitializeTheDGV()
            {
                dgv.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
                dgv.DataSource = itemsList;
                dgv.AutoGenerateColumns = false;
                this.Controls.Add(dgv);
                dgv.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "My col header", Name="mycol1" });
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
    
                /*
                 * Experiment and Pick your poison
                 */
                if (SendAsRow)
                {
                    Form2 f2r = new Form2(dgv.Rows[e.RowIndex]);
                    f2r.Show();
                }
                else
                {
                    Form2 f2 = new Form2((string)dgv.Rows[e.RowIndex].Cells[0].FormattedValue);
                    f2.Show();
                }
                /**/
            }
    
    
            private void AddTheButton()
            {
                independantButton.Location = new Point(this.Location.X + 5, this.Location.Y + dgv2.Height + 15);
                independantButton.Click += IndependantButton_Click;
                this.Controls.Add(independantButton);
            }
    
            private void IndependantButton_Click(object sender, System.EventArgs e)
            {
                /*
                 * Experiment and Pick your poison
                 */
                if (SendAsRow)
                {
                    Form2 f2r = new Form2(dgv.SelectedRows[0]);
                    f2r.Show();
                }
                else
                {
                    Form2 f2 = new Form2((string)dgv.SelectedRows[0].Cells[0].FormattedValue);
                    f2.Show();
                }
                /**/
                
            }
        }
    
    
        public class dgvitem
        {
            public string JustaTextField { get; set; }
        }
    }
