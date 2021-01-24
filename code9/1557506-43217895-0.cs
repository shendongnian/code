    Console.Write("\n\tGissa på ett tal mellan 1 och 20: ");
    int tal;
    if(!Int32.TryParse(Console.ReadLine(), out tal))
    {
        Console.WriteLine("Fel, du får bara skriva in nummer");
        continue;
    }
