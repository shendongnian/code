    var userInput = "1,2,3,4,5,6";
    var values = userInput.Split(',');
    using(var command = new OdbcCommand())
    {
        var sql = "SELECT * FROM table where id IN(";
        for(int i=0; i < values.Count; i++) {
            sql = $"{sql} @{i},";
            command.Parameters.Add($"@{i}", OdbcType.Int).Value = values[i];
        }
        command.CommandText = sql.TrimEnd(",") +");";
        command.Connection = con;
        using(var reader = Command.ExecuteReader())
        {
            while(reader.Read())
            {
                // do your stuff with the data
            }
        }
    }
