    DataTable table = GetDtFromFile();
    DataTable results;
    int startingRow = GetStartingRow();
    int size = table.Rows.Count - startingRow;
    results = table.AsEnumerable().Skip(startingRow).Take(size).CopyToDataTable();
