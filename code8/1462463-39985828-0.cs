    static void Main(string[] args)
    {
        var cultures = new[] {"en-US", "pt-BR", "it", "es"};
        var list = new List<double> {144, 0, 540.23};
    
        Console.WriteLine("Without specifying a culture");
    
        foreach (var culture in cultures.Select(isoCulture => new CultureInfo(isoCulture)))
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
    
            Console.WriteLine("Culture: " + culture.Name);
    
            Console.WriteLine("Not defined:                  " + string.Join(",", list.Select(x => Convert.ToString(x))));
            Console.WriteLine("CultureInfo.InvariantCulture: " + string.Join(",", list.Select(x => Convert.ToString(x, CultureInfo.InvariantCulture))));
        }
        Console.ReadLine(); // stops so you can see the results
    }
