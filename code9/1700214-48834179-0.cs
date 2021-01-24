    Dictionary<string, Cell> cells = new Dictionary<string, Cell>();
    
    //  Assign new cell to 5.0 & print
    cells.Add("a1", new Cell("a1", 5.0));
    Console.WriteLine(cells["a1"].Content);     //  Writes 5
    
    //  Assign cell to new content & print
    cells.TryGetValue("a1", out Cell value);
    value.Content = 10.0;
    cells["a1"] = value;  // update cells Dictionary
    Console.WriteLine(cells["a1"].Content);     //  Writes 5
    Console.ReadKey();
