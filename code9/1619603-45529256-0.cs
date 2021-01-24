        bool SendRow;
        Database _DB = new Database();
        public Form2()
        {
            InitializeComponent();
            LeadsDataGridView.Rows.Add("1", "ABCD", "555-1234", "555-5555", "john doe", "jdoe@email.com", "1");
            LeadsDataGridView.Rows.Add("2", "EFGH", "555-9876", "555-1111", "jane white", "jwhite@email.com", "21");
        }
        //Copy To Database
        private void LeadsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == LeadsDataGridView.Columns.GetFirstColumn(DataGridViewElementStates.None, DataGridViewElementStates.ReadOnly).Index)
            //    DB_Btn_Click(sender, e);
            SendRow = true;
            DataTable DB_Table = new DataTable();
            DataGridView DB_GridView = new DataGridView();
            _DB.AddRow(LeadsDataGridView.Rows[e.RowIndex], SendRow);
            if (!_DB.Visible)
            {
                _DB.Show();
            }
            else
            {
                _DB.BringToFront();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
        }
    }
