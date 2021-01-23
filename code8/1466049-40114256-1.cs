    //Happens in the List<T> in memory
    ViewBag.companySalesTotal = entities.Sum(a => a.Amount);
    var companyStoreTotalItem = entities.GroupBy(m => new { m.Description })
                                        .Select(g => new DescriptionAmountModel { Amount = g.Sum(a => a.Amount).Value, Description = g.Key.Description })
                                        .OrderByDescending(x => x.Amount);
