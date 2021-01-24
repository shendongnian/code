    var productCollection = mongoDatabase.GetCollection<Product>("products");
    var product = productCollection.Find(x => x.Id == doc["_id"]).First();
    Console.WriteLine(product.Id);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Int32Price);
    Console.WriteLine(product.StringPrice);
    Console.WriteLine(product.Decimal128Price);
    // 5a0c581b1a1c8f310049815a
    // Shampoo
    // 33
    // 33.45
    // 33.45
