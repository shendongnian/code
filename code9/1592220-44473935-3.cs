    private void theFilter(string FilterValue) {
        string thisQuery = "SELECT * FROM [Customer] WHERE CONCAT([Name], [Address], [Discount]) LIKE @FilterValue";
        using(SqlConnection thisSqlConnection = new SqlConnection(theConnectionString))
        using(SqlCommand thisSqlCommand = new SqlCommand(thisQuery, thisSqlConnection)) {
            thisSqlCommand.Parameters.AddWithValue("@FilterValue", "%" + SqlLikeEscape(FilterValue) + "%");
            using(SqlDataAdapter thisSqlDataAdapter = new SqlDataAdapter(thisSqlCommand))
            using(DataTable thisDataTable = new DataTable()) {
                thisSqlDataAdapter.Fill(thisDataTable);
                DataGrid_Customer.ItemsSource = thisDataTable.DefaultView;
            }
        }
    }
    // This function is important, since otherwise if there is a % in the table (or other special LIKE characters) then it is hard to search for them
    //see https://stackoverflow.com/questions/18693349/how-do-i-find-with-the-like-operator-in-sql-server
    public static string SqlLikeEscape(string value)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return Regex.Replace(value, @"(?<ch>%|_|\[)", @"[${ch}]");
    }
