        public DataTable DB_Table;
        BindingList<DataPile> DB_GridViewList = new BindingList<DataPile>();
        public Database()
        {
            InitializeComponent();
            InitDBTable();
            DB_GridView.DataSource = DB_GridViewList;
        }
        public void AddRow(DataGridViewRow DB_GridViewRow, bool SendRow)
        {
            if (DB_GridViewList != null && SendRow == true)
            {
                foreach (DataGridViewRow dr in DB_GridView.Rows)
                    if (dr.Cells[0].Value == DB_GridViewRow.Cells[0].Value)
                        return;
                DB_GridViewList.Add(new DataPile
                {
                    UniqueID = (string)DB_GridViewRow.Cells[0].FormattedValue,
                    BusinessName = (string)DB_GridViewRow.Cells[1].FormattedValue,
                    PhoneNumber = (string)DB_GridViewRow.Cells[2].FormattedValue
                });
            }
        }
        public class DataPile
        {
            public string UniqueID { get; set; }
            public string BusinessName { get; set; }
            public string PhoneNumber { get; set; }
            public string MobileNumber { get; set; }
            public string ContactName { get; set; }
            public string Email { get; set; }
            public string MonthlyRevenue { get; set; }
        }
        private void InitDBTable()
        {
            DB_Table = new DataTable("DB_GridTable");
            DB_Table.Columns.Add("UniqueID", typeof(string));            
            DB_Table.Columns.Add("Business Name", typeof(string));
            DB_Table.Columns.Add("Phone Number", typeof(string));
            DB_Table.Columns.Add("Mobile Number", typeof(string));
            DB_Table.Columns.Add("Contact Name", typeof(string));
            DB_Table.Columns.Add("Email", typeof(string));
            DB_Table.Columns.Add("Monthly Revenue", typeof(string));
            DB_GridView.DataSource = DB_Table;
            // Hide UniqueID column
            //DB_GridView.Columns[0].Visible = false;
        }
        private void Database_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true; // this cancels the close event.
        }
    }
