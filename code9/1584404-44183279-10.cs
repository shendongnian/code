    var someItems = new [] { new Iitem { Id = 1 }, new Iitem { Id = 2 } };
    var f = ItemProduct(someItems);
    var prod = new Product { ItemID = 1; }
    //  Results will be an enumeration that will enumerate a single Iitem, the 
    //  one whose Id is 1. 
    var results = f(prod);
