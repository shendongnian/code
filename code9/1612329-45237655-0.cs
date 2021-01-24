    var priceItem = basicQuery.Where(bySeller).Where(byDate).FirstOrDefault();
    if (priceItem != null) return priceItem;
    var priceItem = basicQuery.Where(byDate).FirstOrDefault();
    if (priceItem != null) return priceItem;
    var priceItem = basicQuery.Where(bySeller).FirstOrDefault();
    return basicQuery.FirstOrDefault();
