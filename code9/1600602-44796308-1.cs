    DataTable table = new DataTable();
    int columns = 12;      // if it will change as variable
    bool hasHeader = true; // change accordingly
    var rows = File.ReadAllText(pathToFile)              // reads file as string
        .Split(new[] { '|' }, StringSplitOptions.None)   // split on pipe delimiter to get a string[]
        .Select((field, index) => new { field, index })  // project anonymous type with field and index
        .GroupBy(x => x.index / columns)                 // integer division trick to group by 12 columns
        .Select(g => g.Select(x => x.field).ToArray())   // create a string[] for every row's fields
        .ToArray();                                      // create a string[][]
    for (int i = 0; i < columns; i++)
        table.Columns.Add(hasHeader ? rows.FirstOrDefault()?[i] : null); // add either generated column name or use first row
    for (int i = hasHeader ? 1 : 0; i < rows.Length; i++)
    {
        table.Rows.Add(rows[i]);  // add all 12 fields
    }
