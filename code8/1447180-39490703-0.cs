    var warehouseNames = 
        stocks
        .SelectMany(x => x.Warehouses.Select(y => y.WarehouseName)).Distinct();
    
    var dt = new DataTable();
    dt.Columns.Add("StockCode");
    
    foreach (var name in warehouseNames)
    {
        dt.Columns.Add(name);
    }
    foreach (var stock in stocks)
    {
        var row = dt.NewRow();
        row["StockCode"] = stock.Id;
        foreach (var warehouse in stock.Warehouses)
        {
            row[warehouse.WarehouseName] = warehouse.Id;
        }
        dt.Rows.Add(row);
    }
