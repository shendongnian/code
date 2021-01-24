    List<Item> items = new List<Item>();
    items.Add(new IronOre(200));
    
    var myOtherPile = Item.Split(items[0], 70); // my OtherPile is of type Item
    IronOre myOtherPile = Item.Split(items[0], 70); // error, cast needed
