    var BothTables = Table1.Clone();
    BothTables.Columns.AddRange(Table2.Columns.OfType<DataColumn>()
       .Select(dc => new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping)).ToArray());
    foreach (var vr in v)
        BothTables.Rows.Add(vr.t1.ItemArray.Concat(vr.t2.ItemArray).ToArray());
    var combinedv = BothTables.Rows;
