        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set properties
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Create fictional rows since i dont have your datasource
            dataGridView1.Columns.Add("col1", "col1");
            dataGridView1.Columns.Add("col2", "col2");
            dataGridView1.Columns.Add("col3", "col3");
            int loop = 10;
            for (int i = 0; i < loop; i++)
            {
                DataGridViewRow dgr = new DataGridViewRow();
                dataGridView1.Rows.Add(dgr);
            }
        }
        // After button click (or any other event for that matter)
        private void button1_Click(object sender, EventArgs e)
        {
            // Get all selected rows
            foreach(DataGridViewRow dgvr in dataGridView1.SelectedRows)
            {
                // execute row
                cellClickFunction(dgvr);
            }
        }
        // Pass selected row to cellClickFunction (this is NOT the click event)
        private void cellClickFunction(DataGridViewRow dgvr)
        {
            // Your code
            this.Clear_Print();
            this.mEmpId = Convert.ToInt32(this.dgvr.Cells["empid_Print"].FormattedValue);
            this.lblEmpPrint.Text = this.dgvPrint.dgvr["Empname_Print"].FormattedValue.ToString();
            this.btnPrint.Enabled = true;
        }
