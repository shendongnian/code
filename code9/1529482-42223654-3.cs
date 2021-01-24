    public async Task<DataTable> loadCombo(string sqlCommand, string value)
    {
        var yourConnectionString = "DataSource=...";
        using (var connection = new SqlConnection(yourConnectionString))
        using (var command = new SqlCommand(sqlCommand, connection))
        {
            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            var data = new DataTable();
            data.Load(reader);
            return data;
        }
    }
    
