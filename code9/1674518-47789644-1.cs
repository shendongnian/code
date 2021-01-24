    var commandText = $"insert into {tableName} (@columns) values (@values)";
    var valueBuilder = new StringBuilder();
    var columnBuilder = new StringBuilder();
    var parameterizer = new SqlParameterizer(this.Provider);
    actionValueParameterizer?.Invoke(parameterizer);
    foreach(IDbDataParameter parameter in parameterizer.GetParameters())
    {
        command.Parameters.Add(parameter);
        valueBuilder.Append($",@{parameter.ParameterName}");
        columnBuilder.Append($",{parameter.ParameterName}");
    }
    commandText = commandText.Replace("@values", valueBuilder.ToString().Substring(1));
    commandText = commandText.Replace("@columns", columnBuilder.ToString().Substring(1));
    command.CommandText = commandText;
    command.ExecuteNonQuery();
