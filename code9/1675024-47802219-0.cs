    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace datagridview_47800424
    {
        public partial class Form1 : Form
        {
            List<dgventry> dgvsource = new List<dgventry>();
            DataGridView dgv = new DataGridView();
            public Form1()
            {
                InitializeComponent();
                ourinit();
            }
    
            private void ourinit()
            {
    
                //lets create some records in that list
                for (int i = 0; i < 10; i++)
                {
                    dgvsource.Add(new dgventry { name = $"name {i}", id = i });
                }
                
    
                dgv.AutoGenerateColumns = false;//don't auto create the columns
                DataGridViewColumn dgvcol = new DataGridViewTextBoxColumn();//make your own
                dgvcol.DataPropertyName = "name";//set which property to bind to
                dgv.Columns.Add(dgvcol);//add the col to the grid
    
                
                dgv.DataSource = dgvsource;//bind the grid to your list
    
                this.Controls.Add(dgv);//add the grid to the form
                dgv.Dock = DockStyle.Fill;//just need to position it somehow and this is quick
    
            }
        }
    
    
        public class dgventry
        {
            public string name { get; set; }
            public int id { get; set; }
        }
    }
