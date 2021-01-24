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
                    dgvData.Add(new dgvEntry { col1 = i.ToString(), col2 = i, col3 = i%2 > 0});
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
                if (dgv.CurrentRow.Cells[0].FormattedValue.Equals("1"))
                {
                    chkbx.Checked = true;
                }
                else
                {
                    chkbx.Checked = false;
                }
    
                if (dgv.CurrentRow.Cells[1].FormattedValue.Equals("1"))
                {
                    chkbx2.Checked = true;
                }
                else
                {
                    chkbx2.Checked = false;
                }
    
                if (bool.Parse(dgv.CurrentRow.Cells[2].Value.ToString()))
                {
                    chkbx3.Checked = true;
                }
                else
                {
                    chkbx3.Checked = false;
                }
            }
        }
    
    
        public class dgvEntry
        {
            public string col1 { get; set; }
            public int col2 { get; set; }
            public bool col3 { get; set; }
        }
    }
