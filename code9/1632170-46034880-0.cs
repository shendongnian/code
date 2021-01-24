    // Below is for my sample data
    var dt = new DataTable();
    var idCol = dt.Columns.Add("ID", typeof(int));
    var itemCol = dt.Columns.Add("Item", typeof(string));
    var upCol = dt.Columns.Add("Unit Price", typeof(int));
    var qtyCol = dt.Columns.Add("Qty",typeof(int));
    dt.Rows.Add(8, "Pasta", 20, 1);
    dt.Rows.Add(9, "Pasta", 20, 1);
    // I generate my expected result by using linq
    var mergedData = dt.Rows.OfType<DataRow>()
        .GroupBy(g=> g.ItemArray[itemCol.Ordinal])
        .Select(c=> new
        {
            item = c.Key,
            id = c.FirstOrDefault()?[idCol],                    // I think you need first id as result
            up = c.Average(x=> int.Parse(x[upCol].ToString())), // I think you need average of Unit Prices as result
            qty = c.Sum(x => int.Parse(x[qtyCol].ToString()))   // I think you need sum of Quantity as result
        });
    // A clone of current DataTable will give me its structure without data
    // I use this as a temporary DataTable
    var newDt = dt.Clone();
    foreach (var md in mergedData)
    {
        newDt.Rows.Add(md.id, md.item, md.up, md.qty);
    }
    dt = newDt;
