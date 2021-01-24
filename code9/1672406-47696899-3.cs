    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DataGridViewToXML_47696565
    {
        public partial class Form1 : Form
        {
    
            DataTable dgvdt = new DataTable();
            DataGridView dgv = new DataGridView();
            Button btn = new Button();
            public Form1()
            {
                InitializeComponent();
                InitOurStuff();
            }
    
            private void InitOurStuff()
            {
                this.Controls.Add(dgv);
                dgv.DataSource = dgvdt;
                dgv.Dock = DockStyle.Top;
    
                dgvdt.TableName = "SD";
                dgvdt.Columns.Add();
                for (int i = 0; i < 10; i++)
                {
                    dgvdt.Rows.Add($"row {i}");
                }
    
                this.Controls.Add(btn);
                btn.Location = new Point(5, dgv.Location.Y + dgv.Height + 5);
                btn.Text = "Click me";
                btn.Click += Btn_Click;
    
            }
    
            private void Btn_Click(object sender, EventArgs e)
            {
                dgvdt.WriteXml(@"c:\temp\mydtxml.xml");
            }
        }
    }
