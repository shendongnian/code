    foreach (var thisItem in items)
    {
        if (thisItem.Value.GetType().Name == "Magnet")
        {
            Console.WriteLine("Magnet");
        }
        else
        {
            Console.WriteLine("Motion");
        }
    }
