    //test data
    List<Item> itemsList = new List<Item>();
    itemsList.Add(new Item() { ID = Guid.NewGuid(), Type = "a" });
    itemsList.Add(new Item() { ID = Guid.NewGuid(), Type = "a" });
    itemsList.Add(new Item() { ID = Guid.NewGuid(), Type = "b" });
    itemsList.Add(new Item() { ID = Guid.NewGuid(), Type = "c" });
    
    List<ItemSet> itemSetList = new List<ItemSet>();
    itemSetList.Add(new ItemSet() { ID = Guid.NewGuid(), Items = itemsList });
    
    //select all items
    var allItems = itemSetList.SelectMany(i => i.Items).ToList();
    //filter items by type
    var filteredItems = itemSetList.SelectMany(i => i.Items.Where(x => x.Type == "a")).ToList();
