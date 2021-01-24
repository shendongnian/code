    // String[] data = File.ReadAllLines(@"C:\MyFile.txt");
    String[] data = 
    { 
        "Tilte Code quantity price sum",
        "Item1 item1 2 1.50 3.00",
        "Item2 item2 1 3.00 3.00",
        "good",
        "Item3 item3 2 1.00 2.00"
    };
    CultureInfo ci = new CultureInfo("en-US");
    List<dynamic> objects = new List<dynamic>();
    String title = String.Empty;
    foreach (String line in data.Skip(1))
    {
        String[] parts = line.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 1)
        {
            title = line;
            continue;
        }
        String titleItem = parts[0];
        if (title != String.Empty)
            titleItem += " " + title;
        objects.Add(new
        {
            Title = titleItem,
            Code = parts[1],
            Quantity = Int32.Parse(parts[2]),
            Price = Single.Parse(parts[3], ci),
            Sum = Single.Parse(parts[4], ci),
        });
    }
    foreach (dynamic obj in objects)
    {
        Console.WriteLine("[ENTRY]");
        Console.WriteLine(obj.Title);
        Console.WriteLine(obj.Code);       
        Console.WriteLine(obj.Quantity);
        Console.WriteLine(obj.Price);
        Console.WriteLine(obj.Sum);
        Console.WriteLine();
    }
