    static void Main(string[] args)
    {
        List<string> Mksnos = new List<string>()
        {
            "Toyota",
            "Honda is Good",
            "Innova is very good"
        };
        
        List<string> GdsDscr = new List<string>()
        {
            "Toyota is a very good brand and it is costly",
            "The carmaker's flagship sedan is now here in its hybrid avatar. It is brought to... The Honda Accord Hybrid has been launched in India"
        };
        var joinedLists = new Dictionary<string, string>();
        for (int i = 0; i < Mksnos.Count(); i++)
        {
            var nksnosValue = Mksnos[i];
            var gdsDscr = GdsDscr.Count() > i ? GdsDscr[i] : string.Empty;
            joinedLists.Add(nksnosValue, gdsDscr);
        }
        foreach (var joined in joinedLists)
        {
            Console.WriteLine($"{joined.Key}: {joined.Value}");
        }
        Console.ReadKey();
    }
