    var updateCmd = new OleDbCommand();
    var query = new StringBuilder();
    foreach(KeyValuePair<string, string> value in myValues)
    {
        string columnValue = value.Key;
        query.AppendLine($", {columnName} = ?");
        var param = new OleDbParameter("@v", value.Value); 
        // Name of parameter not important, only order
    }
    if(query.Length > 0)
    {
        query.Remove(0, 1); // Remove first ',' character
        query.Insert("Update [Calculated] SET ");
        query.AppendLine("$WHERE [NSN] = '{NSN}';");
    }
    updateCmd.CommandText = query.ToString();
