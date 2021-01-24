    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace DataGridViewDateTime_47208900
    {
        public partial class Form1 : Form
        {
    
            BindingList<dgvEntry> dgvDataSource = new BindingList<dgvEntry>();
            DataGridView dgv = new DataGridView();
    
            public Form1()
            {
                InitializeComponent();
                InitDGV();
                AddData();
            }
    
            private void AddData()
            {
                for (int i = 0; i < 10; i++)
                {
                    dgvEntry entry = new dgvEntry();
                    entry.name = $"name {i}";
                    entry.id = i;
                    //add DateTime to only some of the entries to get some null values
                    if (i % 2 > 0)
                    {
                        entry.dateTime = DateTime.Now;
                    }
                    dgvDataSource.Add(entry);
                }
            }
    
            private void InitDGV()
            {
                dgv.Dock = DockStyle.Top;
                dgv.AutoGenerateColumns = false;
                DataGridViewColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.DataPropertyName = "name";
                DataGridViewColumn dgvc2 = new DataGridViewTextBoxColumn();
                dgvc2.DataPropertyName = "id";
                DataGridViewColumn dgvc3 = new DataGridViewTextBoxColumn();
                dgvc3.DataPropertyName = "dateTime";
                dgvc3.DefaultCellStyle.NullValue = "bla bla bla"; //What to do when the value is null
                dgv.Columns.Add(dgvc);
                dgv.Columns.Add(dgvc2);
                dgv.Columns.Add(dgvc3);
                dgv.DataSource = dgvDataSource;
                this.Controls.Add(dgv);
            }
        }
    
        public class dgvEntry
        {
            public string name { get; set; }
            public int id { get; set; }
            public DateTime? dateTime { get; set; }
        }
    }
