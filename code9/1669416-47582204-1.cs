    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestConsole
    {
        public class Program
        {
            public class CountryAndCity
            {
                public string Country { get; set; }
                public string City { get; set; }
            }
    
            static void Main(string[] args)
            {
                var cities = new List<CountryAndCity>
                {
                    new CountryAndCity() {Country = "Australia", City = "Sydney"},
                    new CountryAndCity() {Country = "Argentina", City = "Buenos Aires"},
                    new CountryAndCity() {Country = "Paraguay", City = "Asuncion"},
                    new CountryAndCity() {Country = "Abadeh", City = "Iran"}
                };
    
                // The important bit starts here
                var results = cities
                    .Where(z => z.Country.StartsWith("A") || z.City.StartsWith("A")) // this line is optional (only needed if you want to remove those that don't start with A
                    .Select(z =>
                        new
                        {
                            OriginalData = z,
                            Match = z.Country.StartsWith("A") ? z.Country : z.City.StartsWith("A") ? z.City : "ZZZZZZ"
                        })
                    .OrderBy(z => z.Match)
                    .Select(z => z.OriginalData);
                // The important bit ends here
    
                Console.WriteLine(string.Join("\r\n", results.Select(z => $"{z.Country}-{z.City}")));
    
                Console.ReadLine();
            }
        }
    }
