    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace datagridview
    {
        public partial class Form1 : Form
        {
            private DataGridView dgvMachines;
    
            public Form1()
            {
                InitializeComponent();
                //this is the Designer.cs code...
                this.dgvMachines = new System.Windows.Forms.DataGridView();
                ((System.ComponentModel.ISupportInitialize)(this.dgvMachines)).BeginInit();
                this.SuspendLayout();
                // 
                // dgvMachines
                // 
                this.dgvMachines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dgvMachines.Location = new System.Drawing.Point(12, 12);
                this.dgvMachines.Name = "dgvMachines";
                this.dgvMachines.Size = new System.Drawing.Size(606, 400);
                this.dgvMachines.TabIndex = 0;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(630, 434);
                this.Controls.Add(this.dgvMachines);
                this.Name = "Form1";
                this.Text = "Form1";
                ((ISupportInitialize)(this.dgvMachines)).EndInit();
                this.ResumeLayout(false);
    
                IList<Machine> machines = new BindingList<Machine>();
                dgvMachines.DataSource = machines;
                machines.Add(new Machine { Name = "#1", CashCount = 100 });
                machines.Add(new Machine { Name = "#2", CashCount = 200 });
                machines.Add(new Machine { Name = "#3", CashCount = 300 });
                machines.Add(new Machine { Name = "#4", CashCount = 400 });
            }
        }
    
        class Machine
        {
            public string Name { get; set; }
            public decimal CashCount { get; set; }
        }
    }
