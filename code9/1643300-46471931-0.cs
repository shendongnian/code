    using(var command = new OdbcCommand())
    {
        string sql = "SELECT name, value FROM my_table WHERE name IN(";
        for(int i=0; i < names.Count; i++) {
            sql = $"{sql} @{i},";
            command.Parameters.Add($"@{i}", OdbcType.VarChar).Value = names[i];
        }
        
        command.CommandText = sql.TrimEnd(",") +");";
        command.Connection = con;
        // fill a data set or execute a data reader here....
    }
