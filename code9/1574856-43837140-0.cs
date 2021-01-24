    var dt = new DataTable("Rows");   // or whatever table name you want
    using (var reader = new StreamReader(spreadSheetStream))
    {
        reader.ReadLine()?.Split(',').ToList().ForEach(h => dt.Columns.Add(h));
        while (!reader.EndOfStream)
        {
            dt.Rows.Add(reader.ReadLine()?.Split(',').ToList());
        }
    }
