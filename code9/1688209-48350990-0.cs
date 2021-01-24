    var dt = new DataTable();
    var cols = new[]
    {
        new DataColumn("OrderDetailId", typeof(int)),
        new DataColumn("OrderId", typeof(string)),
        new DataColumn("Product", typeof(string)),
        new DataColumn("UnitPrice", typeof(decimal)),
        new DataColumn("OrderQty", typeof(int))
    };
    dt.Columns.AddRange(cols);
    
    
    object[] rows =
    {
        new object[] {1, "O0001", "Mountain Bike", 1419.5, 36},
        new object[] {2, "O0001", "Road Bike", 1233.6, 16},
        new object[] {3, "O0001", "Touring Bike", 1653.3, 32},
        new object[] {4, "O0002", null, 1419.5, 24},
        new object[] {5, "O0002", "Road Bike", 1233.6, 12},
        new object[] {6, "O0003", "Mountain Bike", null, 48},
        new object[] {7, "O0003", "Touring Bike", 1653.3, 8},
    };
    
    foreach (object[] row in rows)
        dt.Rows.Add(row);
    
    var dtRows = dt.AsEnumerable().Select(x => x.ItemArray).ToList();
    var rowsWithNullValue = dtRows.Where(x => x.Any(y => y == null || y == DBNull.Value)).ToList();
    
    if (dtRows.Any(x => x.Any(y => y == null || y == DBNull.Value)))
    {
        var nullRecordCount = rowsWithNullValue.SelectMany(x => x).Count(x => x == null || x == DBNull.Value);
        Console.WriteLine($"The table contains ({nullRecordCount}) null values.");
    }
