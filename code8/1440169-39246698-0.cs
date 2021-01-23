    DataTable dt = new DataTable();
    dt.Columns.Add();
    dt.Columns.Add();
    dt.Columns.Add();
    dt.Rows.Add(1, "Test1", "Sample1");
    dt.Rows.Add(2, "Test2", "Sample2");
    dt.Rows.Add(3, "Test3", "Sample3");
    dt.Rows.Add(4, "Test4", "Sample4");
    dt.Rows.Add(5, "Test5", "Sample5");
    
    var duplicates = dt.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1).ToList();
    Console.WriteLine("Duplicate found: {0}", duplicates.Any());
    
    dt.Rows.Add(1, "Test6", "Sample6");  // Duplicate on 1
    dt.Rows.Add(1, "Test6", "Sample6");  // Duplicate on 1
    dt.Rows.Add(3, "Test6", "Sample6");  // Duplicate on 3
    dt.Rows.Add(5, "Test6", "Sample6");  // Duplicate on 5
    
    duplicates = dt.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1).ToList();
    if (duplicates.Any())
        Console.WriteLine("Duplicate found for Classes: {0}", String.Join(", ", duplicates.Select(dupl => dupl.Key)));
    
    Console.ReadLine();
