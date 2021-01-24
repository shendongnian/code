    List<MyItem> groupedItemsByCat01 = myItemList.Where(z => z.Category.Equals("01"))
                                                 .GroupBy(a => a.Category)
                                                 .Select(b=> new MyItem{
                                                    Vendor = b.First().Vendor,
                                                    Cost = b.Sum(c => c.Cost),
                                                    Category = b.First().Category
                                               }).ToList();
    List<MyItem> groupedItemsByOther = myItemList.Where(z => !z.Category.Equals("01"))
                                                 .GroupBy(a => new {a.Category, a.Vendor})
                                                 .Select(b=> new MyItem{
                                                    Vendor = b.First().Vendor,
                                                    Cost = b.Sum(c => c.Cost),
                                                    Category = b.First().Category
                                                 }).ToList();
    List<MyItem> final = new List<MyItem>();
    final.AddRange(groupedItemsByCat01);
    final.AddRange(groupedItemsByOther);
