    List<Tuple<string, string>> columnNames = dict.Where(pair => checkedCheckBoxes.Contains(pair.Key)).Select(pair => pair.Value).ToList();
    string selectColumnNames = string.Join(", ", columnNames.Select(t => t.Item1).ToArray());
    
    string whereClause = "";
    for (int i = 0; i < columnNames.Count(); i++)
    {
        if (i > 0) whereClause +=" and ";
        whereClause += string.Format("{0} = @{0}", columnNames[i]);
    }
