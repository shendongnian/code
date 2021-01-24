    // Simple: quotation "..." e.g. "123,456",789 is not implemented 
    private static DataTable FromCsvSimple(string path, char delimiter = ',') {
      // Try avoiding ReadAllLines; use ReadLines
      // Where - let's skip empty lines (if any)
      var lines = File
        .ReadLines(path)
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Select(line => line.Split(delimiter));
      DataTable result = new DataTable();
      foreach (string[] items in lines) {
        // Do we have any columns to add?
        for (int c = 0; c < items.Length; ++c) 
          while (c >= result.Columns.Count)
            result.Columns.Add();
        result.Rows.Add(items);
      }
      return result;
    }
    ...
    DataTable myTable = FromCsvSimple(@"c:\MyCsv.csv", ';');
