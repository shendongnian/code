    var query = dt.AsEnumerable()
        .GroupBy(row => row.Field<int>("Propertyid"))
        .Select(grp => new { 
            Propertyid     = grp.Key,
            Quantity       = grp.Sum(row => row.Field<int>("Quantity")),
            ActualQuantity = grp.First().Field<int>("ActualQuantity")       
        });
    var SumByIdTable = dt.Clone();
    foreach(var x in query)
        SumByIdTable.Rows.Add(x.Propertyid, x.Quantity, x.ActualQuantity);
