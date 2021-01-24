    var stringCollection = new Collection<string>();
    // Populate here
    var index = stringCollection.IndexOf("Russia");
    if(index > -1)
    {
        stringCollection.RemoveAt(index);
        Console.WriteLine("Russia removed from the collection");
    }
    else
    {
        Console.WriteLine("Russia not found in the collection");
    }
