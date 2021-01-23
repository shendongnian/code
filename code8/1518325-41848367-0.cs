    using System;
    using System.Data;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private System.Windows.Forms.DataGridViewButtonColumn ButtonColumn;
            private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeColumn;
        
            public Form1()
            {
                //Add a DataGridView control to your form, call it "dataGridView1"
                InitializeComponent();
                EmployeeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn()
                {
                    Name = "Employee"
                };
                ButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn()
                {
                    Text = "Pay"
                };
                dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { EmployeeColumn, ButtonColumn });
                //Populate this as required
                var oDataTable = new DataTable();
                oDataTable.Columns.Add("Employee", typeof(String));
                dataGridView1.Rows.Add("Tom", ButtonColumn.Text);
                dataGridView1.Rows.Add("Dick", ButtonColumn.Text);
                dataGridView1.Rows.Add("Harry", ButtonColumn.Text);
            }
        }
    }
