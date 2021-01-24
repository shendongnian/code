    var groupedList = list.GroupBy(p => new
    {
        ProductId = p.Product.Id > 5 ? p.Product.Id : (int?)null,
        ColorId = p.ColorId > 5 ? p.ColorId : (int?)null,
        PieceId = p.PieceId > 5 ? p.PieceId : (int?)null
    })
    .Select(x =>
    new
    {
        x.Key.ProductId,
        x.Key.ColorId,
        x.Key.PieceId
    });
