    List<Item> items = new List<Item>();
    items.Add(new IronOre(200));
    
    var myOtherPile = Item.Split<IronOre>(items[0] as IronOre, 70); // works
    
    IronOre item = items[0] as IronOre;
    myOtherPile = Item.Split(item, 70); // also works
