    string sql = "your query goes here";
    int fromPos = sql.IndexOf("from ", StringComparison.InvariantCultureIgnoreCase);
    if (fromPos == -1)
    {
        MessageBox.Show("No FROM in the SQL, unable to parse tables.");
        return;
    }
    string fromPart = sql.Substring(fromPos);
    Regex tableRegex = new Regex(@"from\s*(\w*)|join\s*(\w*)|,\s*(\w*)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
    var ms = tableRegex.Matches(fromPart);
    List<string> usedTableNames = new List<string>();
    foreach (Match m in ms)
    {
        string tableName = m.Groups[1].Value;
        if (tableName == "") tableName = m.Groups[2].Value;
        if (tableName == "") tableName = m.Groups[3].Value;
        usedTableNames.Add(tableName.ToUpperInvariant());
    }
