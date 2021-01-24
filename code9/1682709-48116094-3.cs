    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DGVBiggerThanContainer_48112281
    {
        public partial class Form1 : Form
        {
            DataGridView dataGridView1 = new DataGridView();
            BindingList<dgventry> dgvdata = new BindingList<dgventry>();
            public Form1()
            {
                InitializeComponent();
    
    
                //comment or uncomment appropriate line to
                //trigger the desired behavior
                //FixedInit();
                //origInit();
                //DockingIniti(DockStyle.Bottom);
                DockingIniti(DockStyle.Fill);
                //DockingIniti(DockStyle.Left);
                //DockingIniti(DockStyle.Right);
                //DockingIniti(DockStyle.Right);
                //DockingIniti(DockStyle.Top);
    
    
    
                Controls.Add(dataGridView1);
                dataGridView1.DataSource = dgvdata;
    
                for (int i = 0; i < 10; i++)
                {
                    dgvdata.Add(new DGVBiggerThanContainer_48112281.dgventry
                    {
                        col1 = $"col1row{i}",
                        col2 = $"col2row{i}",
                        col3 = $"col3row{i}",
                        col4 = $"col4row{i}",
                        col5 = $"col5row{i}",
                        col6 = $"col6row{i}"
                    });
                }
    
    ;        }
    
            private void DockingIniti(DockStyle whereToDock)
            {
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    
                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.AllowUserToDeleteRows = false;
                this.dataGridView1.AllowUserToResizeColumns = false;
                this.dataGridView1.AllowUserToResizeRows = false;
                this.dataGridView1.BackgroundColor = System.Drawing.Color.SandyBrown;
                this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.RowTemplate.Height = 24;
    
    
                dataGridView1.Dock = whereToDock;
                switch (whereToDock)
                {
                    case DockStyle.None:
                        break;
                    case DockStyle.Top:
                        break;
                    case DockStyle.Bottom:
                        break;
                    case DockStyle.Left:
                    case DockStyle.Right:
                        dataGridView1.Width = 500;
                        break;
                    case DockStyle.Fill:
                        break;
                    default:
                        break;
                }
            }
    
            /// <summary>
            /// this is your version
            /// </summary>
            private void origInit()
            {
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    
                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.AllowUserToDeleteRows = false;
                this.dataGridView1.AllowUserToResizeColumns = false;
                this.dataGridView1.AllowUserToResizeRows = false;
                this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.dataGridView1.BackgroundColor = System.Drawing.Color.SandyBrown;
                this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                this.dataGridView1.Location = new System.Drawing.Point(43, 256);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.RowTemplate.Height = 24;
                this.dataGridView1.Size = new System.Drawing.Size(1167, 349);
    
            }
    
    
            /// <summary>
            /// this is your version with my line added
            /// </summary>
            private void FixedInit()
            {
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    
                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.AllowUserToDeleteRows = false;
                this.dataGridView1.AllowUserToResizeColumns = false;
                this.dataGridView1.AllowUserToResizeRows = false;
                this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.dataGridView1.BackgroundColor = System.Drawing.Color.SandyBrown;
                this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                this.dataGridView1.Location = new System.Drawing.Point(43, 256);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.RowTemplate.Height = 24;
                this.dataGridView1.Size = new System.Drawing.Size(1167, 349);
    
                Size = new Size(dataGridView1.Location.X + dataGridView1.Width + 25, dataGridView1.Height + dataGridView1.Location.Y + 125);
            }
        }
    
    
        public class dgventry
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
            public string col4 { get; set; }
            public string col5 { get; set; }
            public string col6 { get; set; }
        }
    }
