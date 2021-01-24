    while (Reader.Read())
    {
        var lines = new List<string>();
        foreach (string ColumnName in cols)
        {
            sb.Append('"' + Reader[ColumnName].ToString() + "\","); 
        }
        lines.Add(sb.ToString());    
        sb.Clear();
    }
    var path = OutputDir + @"\" + TableName + ".dat";
    File.WriteAllLines(path, lines, Encoding.UTF8);
