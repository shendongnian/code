    private async Task<int> ExecuteClause(string clause)
    {
        var connectionString = ConfigurationManager
                     .ConnectionStrings["default"].ConnectionString;
        using (var connection = new SqlConnection(connectionString)) {
            await connection.OpenAsync();
    
            var r = await new SqlCommand(clause, connection).ExecuteReaderAsync();
    
            while (await r.ReadAsync())
            {
                ...
            }
    
            r.Close();
    
            connection.Close();
        }
        // Just an example returning an int
        return 1;
    }
