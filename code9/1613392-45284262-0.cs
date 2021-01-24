    string connectionString = "Data Source=myDataSource;Initial Catalog=MyInitialCatalog;Persist Security Info=True;User ID=myID;Password=myPassword";
    string sql = "SELECT * FROM JournalItems";
    sDs = new DataSet();
    sDs.Tables.Add("JournalItems");
    using(var connection = new SqlConnection(connectionString))
    {
        using(var sCommand = new SqlCommand(sql, connection))
        {
            using(var sAdapter = new SqlDataAdapter(sCommand))
            {
                sAdapter.Fill(sDs, "JournalItems");
            }
        }
    }
    journalItemsDataGridView.DataSource = sDs.Tables["JournalItems"];
    journalItemsDataGridView.ReadOnly = true;
    saveData.Enabled = false;
    journalItemsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
