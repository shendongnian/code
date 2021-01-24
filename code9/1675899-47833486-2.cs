    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            DataGridView dgv = new DataGridView();
            BindingList<dgvitem> dgvdata = new BindingList<dgvitem>();
            public Form2()
            {
                InitializeComponent();
                initours();
    
    
                //add data
                for (int i = 0; i < 10; i++)
                {
                    dgvdata.Add(new dgvitem { checkcol = false, col2 = $"col2 row {i}" });
                }
    
    
                //check one of them
                dgvdata[2].checkcol = true;
    
            }
    
            private void initours()
            {
                this.Controls.Add(dgv);
                dgv.Dock = DockStyle.Fill;
                dgv.DataSource = dgvdata;
            }
        }
    
    
    
        public class dgvitem
        {
            public bool checkcol { get; set; }
            public string col2 { get; set; }
        }
    }
