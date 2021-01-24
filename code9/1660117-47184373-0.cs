    var nameGroups = TableA.AsEnumerable().GroupBy(r => r.Field<string>("Name"));
    var TableB = TableA.Clone();
    TableB.Columns["QuantitySold"].ColumnName = "TotalSold";
    
    foreach(var g in nameGroups)
    {
        TableB.Rows.Add(g.Key, g.Sum(r => r.Field<int>("QuantitySold")));
    }
