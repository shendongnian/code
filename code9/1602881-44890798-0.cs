     private async Task<IEnumerable<RetriveTableData>> GetDataAsync()
     {
        var query = "SELECT * from tblBook";
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(query, connection))
        {
            await connection.OpenAsync();
            using (var reader = command.ExecuteReaderAsync())
            {
                var data = new List<RetriveTableData>();
                while(await reader.ReadAsync())
                {
                    var temp = new RetriveTableData
                    {
                        EmpId = reader["C_FICH"].ToString();
                        EmpName = reader["C_SITE"].ToString();
                        AccessionNo = reader["accessionNo"].ToString();
                        Obj.Author = reader["author"].ToString();
                    };
                    data.Add(temp);
                }
                return data;
            }
        }
    }
