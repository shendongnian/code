    var item = db.Stock_On_Hand_Files
        .Where(p => p.Product == "00009E85 " && p.Location == "A_DOMEST")
        .First();
    var arr = new[] { item.WK_001, item.WK_002, item.WK_003, ... continue for all weeks };
    var result = arr.Select((x, i) => new
    {
        Product = item.Product,
        Location = item.Location,
        Column = (i+1).ToString(),
        SOH = x
    });
