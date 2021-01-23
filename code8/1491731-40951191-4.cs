    for (int i = 0; i < data.First().Value.Count; i++)
    {
        var partial = data.ToDictionary(x => x.Key, x => x.Value.ElementAt(i));
    
        Console.WriteLine("i={0}", i);
        foreach(var item in partial)
        {
            Console.WriteLine("Key={0}    Value={1}",item.Key, item.Value);
        }
    }
