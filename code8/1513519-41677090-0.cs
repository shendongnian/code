    var command = new SqlCommand();
    
    var insertString = $"insert into {tableName} values (";
    var sb = new StringBuilder(insertString);
    int i = 0;
    foreach (var item in data)
    {
        sb.Append("@P").Append(i).Append(",");
        command.Parameters.Add("@P" + i, SqlDbType.VarChar).Value = item.Value;
    }
    command.Connection = connection;
    command.CommandText = sb.ToString().TrimEnd(",") + ");";
    command.ExecuteNonQuery();
