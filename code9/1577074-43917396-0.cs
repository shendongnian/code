    List<MyItem> groupedItems = myItemList.GroupBy(a=> new {a.Category, Vendor= a.Category == "01" ? null : a.Vendor})
          .Select(b=> new MyItem{
                Vendor = b.First().Vendor,
                Cost = b.Sum(c => c.Cost),
                Category = b.First().Category
           }).ToList();
