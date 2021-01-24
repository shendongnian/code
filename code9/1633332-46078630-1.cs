    var lines = new List<string>();
    while (Reader.Read())
    {
        foreach (string ColumnName in cols)
        {
            sb.Append('"' + Reader[ColumnName].ToString() + "\","); 
        }
        lines.Add(sb.ToString());    
        sb.Clear();
    }
    var path = OutputDir + @"\" + TableName + ".dat";
    File.WriteAllLines(path, lines, Encoding.UTF8);
