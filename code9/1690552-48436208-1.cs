    static void Main(string[] args)
    {
        int YEARHIGH        = 2050;
        int YEARLOW         = 1700;
        decimal PRICEHIGH   = 900000m;
        decimal PRICELOW    = 5000m;
        var values = File.ReadLines(@"C:\Users\yetih\Desktop\Firm_Inventory.csv")
                 .Skip(1)
                 .Select(v => DataValues.FromCSV(v))
                 .Where(r => r.yearBuilt > YEARLOW && r.yearBuilt < YEARHIGH && r.price > PRICELOW && r.price < PRICEHIGH)
                 .ToList();
        int maxYearBuilt = values.Max(r => r.yearBuilt);
        int minYearBuilt = values.Min(r => r.yearBuilt);
        int avgYearBuilt = Convert.ToInt32(values.Average(r => r.yearBuilt));
        decimal maxPrice = values.Max(r => r.price)
        decimal minPrice = values.Min(r => r.price);
        decimal avgPrice = values.Average(r => r.price);
        Console.WriteLine("Low      - Year Built: {0}", maxYearBuilt);
        Console.WriteLine("High     - Year Built: {0}", minYearBuilt);
        Console.WriteLine("Average  - Year Built: {0}", avgYearBuilt);
        Console.WriteLine("High     - Price: {0,9:C}", maxPrice);
        Console.WriteLine("Low      - Price: {0,9:C}", minPrice);
        Console.WriteLine("Average  - Price: {0,9:C}", avgPrice);
        Console.ReadKey(true);
    }
