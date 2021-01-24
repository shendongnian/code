    void Main()
    {
    	List<Item> itemList = new List<Item>();
    
    	itemList.Add(new Item { ItemID = 1, ItemQty = 20m });
    	itemList.Add(new Item { ItemID = 2, ItemQty = 10m });
    	itemList.Add(new Item { ItemID = 1, ItemQty = 30m });
    	itemList.Add(new Item { ItemID = 3, ItemQty = 40m });
    
    	var itemGroup = itemList.GroupBy(i => i.ItemID).Select(g => new { ItemID = g.Key, TotalQty = g.Select(j => j.ItemQty).Sum() });
    	foreach (var i in itemGroup)
    		Console.WriteLine($"{i.ItemID}: {i.TotalQty}");
    }
.
