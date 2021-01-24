    var allCols = dt.Columns
                    .Cast<DataColumn>()
                    .Select(col => col.ColumnName.Replace("Apat", ""))
                    .ToArray();
    
    foreach (DataRow r in dt.Rows)
    {
        var firstCol =
        r.ItemArray.Select((cell, position) => Tuple.Create(Convert.ToInt32(cell), position))
                   .Where(tuple => tuple.Item1 > 0)
                   .FirstOrDefault();
    
        var colName = allCols[firstCol.Item2];
    
        var FirstAvailableDate = WorkDate.AddDays((dec)colName).ToShortDateString;
        //use data in someway
    }
