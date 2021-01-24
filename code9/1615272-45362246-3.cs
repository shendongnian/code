    foreach (var thisItem in items)
    {
        // or use thisItem.Value is Magnet
        if (thisItem.Value.GetType().Name == "Magnet")
        {
            Console.WriteLine("Magnet");
        }
        else
        {
            Console.WriteLine("Motion");
        }
    }
