    private void theFilter(string FilterValue) {
        string thisQuery = "SELECT * FROM [Customer] WHERE CONCAT([Name], [Address], [Discount]) LIKE @FilterValue";
        using(SqlConnection thisSqlConnection = new SqlConnection(theConnectionString))
        using(SqlCommand thisSqlCommand = new SqlCommand(thisQuery, thisSqlConnection)) {
            thisSqlCommand.Parameters.AddWithValue("@FilterValue", "%" + FilterValue + "%");
            using(SqlDataAdapter thisSqlDataAdapter = new SqlDataAdapter(thisSqlCommand))
            using(DataTable thisDataTable = new DataTable()) {
                thisSqlDataAdapter.Fill(thisDataTable);
                DataGrid_Customer.ItemsSource = thisDataTable.DefaultView;
            }
        }
    }
