    static void Main()
    {
        var lines = new List<string>
        {
            "1-05-2017,Early May bank holiday, scotland",
            "1-08-2016,Summer bankholiday, scotland",
            "1-12-2014,St Andrew's Day,scotland",
            "14-04-2017,Good Friday, england-and-wales"
        };
        var orderedLines = lines.OrderByDescending(x => 
            DateTime.ParseExact(x.Split(',')[0], "d-MM-yyyy", 
                CultureInfo.InvariantCulture)).ToList();
        foreach (var line in orderedLines)
        {
            Console.WriteLine(line);
        }
        Console.CursorVisible = false;
        Console.Write("\nPress any key to exit...");
        Console.ReadKey();
    }
