    public void Craft(string result) {
        var itemCounts = recipes[result].GroupBy(x=>x.Material, 
            (string key, IEnumerable<Item> values) => 
                new { Material = key, Total = values.Sum(y=>y.Count) } );
        if (itemCounts.All(x=>HasItem(x.Material, x.Total)) {
            AddNew (result, 1);
        }
    }
