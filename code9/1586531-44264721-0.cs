    List<DataRow> list =  getxml_table.AsEnumberable().ToList();
    using (var writer = new StreamWriter(@"c:\temp\1.txt"))
    {
        foreach(var row in list)
        {
            writer.WriteLine(row["column_name"]);
        }
    }
