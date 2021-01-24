    var newList = myItemList
        .Where(item => item.Category != "01")
        .GroupBy(item => new {item.Category, item.Vendor})
        .Select(group => new MyItem()
        {
            Vendor = group.Key.Vendor,
            Category = group.Key.Category,
            Cost = group.Sum(item => item.Cost)
        })
        .Union(new[]
        {
            new MyItem()
            {
                Vendor = "N/A",
                Category = "01",
                Cost = myItemList.Where(item => item.Category == "01").Sum(item => item.Cost)
            }
        });
    foreach (var loItem in newList)
    {
        Debug.WriteLine("Category = {0}, Vendor = {1}, Cost = {2}", 
            loItem.Category, loItem.Vendor, loItem.Cost);
    }
