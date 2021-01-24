    var price = node.Select("price");
    while (price.MoveNext())
    {
        string currentPriceValue = price.Current.Value;
        Console.WriteLine(currentPriceValue); // Prints 8.99
    }
