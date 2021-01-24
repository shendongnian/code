    var queryString = $"SELECT * FROM DATATABLE";
    var command = new OracleCommand(queryString, connection);
    var reader = command.ExecuteReader();
    var modelList = new List<RowModel>();
    while (reader.Read())
    {
        modelList.Add(new RowModel
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID")),
            JsonString = (string)reader.GetOracleClob(reader.GetOrdinal("JSON")).Value
        });
    }
