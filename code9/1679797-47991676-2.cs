    var input = Console.ReadLine();
    try
    {
        fahr = Convert.ToDouble(input);
    }
    catch (Exception e)
    {
        Console.WriteLine("Du kan bara skriva in siffor, testa igen.");
        continue;
    }
