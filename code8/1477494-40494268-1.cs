    var namen = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
    bool gedaan = false;
    
    while (!gedaan)
    {
        Console.Write("geef je naam: ");
        var naam = Console.ReadLine().Trim();
        gedaan = naam == "";
    
        if (!gedaan)
        {
            if (!namen.Add(naam))
            {
                Console.WriteLine("naam is al toegevoegd");
            }
        }
    };
    
    Console.WriteLine($"totale party kosten: {namen.Count * 10} euro");
    
    Console.ReadLine();
