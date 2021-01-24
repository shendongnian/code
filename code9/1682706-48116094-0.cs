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
                FixedInit();
                //origInit();
    
    
                Controls.Add(dataGridView1);
                dataGridView1.DataSource = dgvdata;
    
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
