    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class Stock
    {
        public string Name { get; set; }
        public List<Dictionary<string, decimal>> DailyClosePrice { get; set; }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("test.json");
            var stocks = JsonConvert.DeserializeObject<List<Stock>>(json);
            
            foreach (var stock in stocks)
            {
                Console.WriteLine($"Name: {stock.Name}");
                Console.WriteLine("Prices:");
                // Assume there's only ever a single entry, at least for now...
                var prices = stock.DailyClosePrice.Single();
                // TODO: Parse the (ugly, US-based) date format...
                var entries = prices.Select(kvp => new { Date = kvp.Key, Price = kvp.Value });
                foreach (var entry in entries)
                {
                    Console.WriteLine($"  {entry.Date}: {entry.Price}");
                }
            }
        }
    }
