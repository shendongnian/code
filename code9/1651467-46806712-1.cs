    string EmployeeIds = "'1231','1232','1233'";
    var values = EmployeeIds.Split(',');
    using(var command = new OdbcCommand())
    {
        var sql = "SELECT [Employee Number], [Employee Name], [First In Time], [Last Out Time], [Total Work Hours] "+
                  "FROM [Sheet0$A2:J] "+
                  "WHERE [Employee Number] IN (";
        for(int i=0; i < values.Length; i++) 
        {
            // Please note that string interpolation will work only with c# 6 or later.
            // If you are working with vs 2013 or earlier, use string.Format instead.
            sql = $"{sql} @{i},";
            command.Parameters.Add($"@{i}", OdbcType.Int).Value = values[i];
        }
        command.CommandText = sql.TrimEnd(',') +");";
        command.Connection = con;
        using(var reader = Command.ExecuteReader())
        {
            while(reader.Read())
            {
                // do your stuff with the data
            }
        }
    }
