    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace CheckACheckBoxByClickingDataGridView_47102655
    {
        public partial class Form1 : Form
        {
            BindingList<dgvEntry> dgvData = new BindingList<dgvEntry>();
            DataGridView dgv = new DataGridView();
            GroupBox gp = new GroupBox();
            CheckBox chkbx = new CheckBox();
            CheckBox chkbx2 = new CheckBox();
            CheckBox chkbx3 = new CheckBox();
    
            public Form1()
            {
                InitializeComponent();
                InitGrid();
                AddData();
                InitGroupBox();
            }
    
            private void InitGroupBox()
            {
                gp.Dock = DockStyle.Bottom;
                this.Controls.Add(gp);
                chkbx.Location = new Point(5, 5);
                chkbx2.Location = new Point(5, 25);
                chkbx3.Location = new Point(5, 45);
                gp.Controls.Add(chkbx);
                gp.Controls.Add(chkbx2);
                gp.Controls.Add(chkbx3);
            }
    
            private void AddData()
            {
                for (int i = 0; i < 10; i++)
                {
                    dgvData.Add(new dgvEntry { id = i, age = i + 20, fullname = $"Name{i}", sex = i > 4? "Male" : "Female", date = DateTime.Now});
                }
            }
    
            private void InitGrid()
            {
                dgv.Dock = DockStyle.Top;
                dgv.AutoGenerateColumns = true;
                dgv.DataSource = dgvData;
                this.Controls.Add(dgv);
                dgv.DoubleClick += Dgv_DoubleClick;
            }
    
            private void Dgv_DoubleClick(object sender, EventArgs e)
            {
                if (dgv.CurrentRow.Cells[3].FormattedValue.Equals("Male"))
                {
                    chkbx.Checked = true;
                }
                else
                {
                    chkbx.Checked = false;
                }
            }
        }
    
    
        public class dgvEntry
        {
            public int id { get; set; }
            public string fullname { get; set; }
            public int age { get; set; }
            public string sex { get; set; }
            public DateTime date { get; set; }
        }
    }
