    public static string GetJSON(string connectionString, string tableName)
    {
        try
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(dataTable.Rows);
            return json;
        }
        catch { return string.Empty; }
    }
