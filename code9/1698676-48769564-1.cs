    List<CsvRow> rows = new List<CsvRow>();
    StreamReader file = new System.IO.StreamReader(employeedatabase);
    string line3 = file.ReadLine();
    while ((line3 = file.ReadLine()) != null)
    {
        rows.Add(new CsvRow(line3.Split(';'));
    }
