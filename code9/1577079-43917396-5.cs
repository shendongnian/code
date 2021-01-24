    List<MyItem> groupedItems = myItemList
          .GroupBy(a=> new {a.Category, Vendor= a.Category == "01" ? "N/A" : a.Vendor})
          .Select(b=> new MyItem{
                Vendor = b.Key.Vendor,
                Cost = b.Sum(c => c.Cost),
                Category = b.Key.Category
           }).ToList();
