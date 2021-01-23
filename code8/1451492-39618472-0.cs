    var typeGroups = Table1.AsEnumerable()
        .Concat(Table2.AsEnumerable())              // all rows in one sequence
        .GroupBy(row => row.Field<string>("Type")); // group all by type 
    DataTable Table3 = Table1.Clone();              // empty, same columns
    foreach (var typeGroup in typeGroups)
    {
        DataRow newRow = Table3.Rows.Add();         // added already now
        newRow.SetField("Type", typeGroup.Key);
        newRow.SetField("Count", typeGroup.Sum(row => row.Field<int>("Count")));
    }
