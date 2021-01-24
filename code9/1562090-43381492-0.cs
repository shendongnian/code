    var columns = splitExpression.Split(line).Where(s => s != delimiter).ToList();
    if (headers == null) headers = new string[columns.Count];
    if (columns.Count != headers.Length)
    {
        columns[10] = columns[10] + columns[11]; // combine columns here
        columns.RemoveAt(11);       
    }
    
    writer.WriteLine(string.Join(delimiter, columns));
