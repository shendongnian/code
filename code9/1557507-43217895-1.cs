    Console.Write("\n\tGissa på ett tal mellan 1 och 20: ");
    int tal;
    try
    {
       tal = Int32.Parse(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Fel, du får bara skriva in nummer");
        continue;
    }
