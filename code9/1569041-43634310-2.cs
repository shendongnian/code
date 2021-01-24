    cartall.CartItems = cartdatas.Select(a => new Models.DTO.CartDTO.CartVM()
    {
        VariationId = a.VariationId,
        ColorName = a.ColorName,
        StockInfo = GetColumnValue(rpstock.FirstOrDefault(x => x.Id == a.VariationId).ToList(), a.ColorName)
    }).ToList();
