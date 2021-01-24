    using System;
    using System.Diagnostics;
    using System.Linq;
    
    namespace Test {
        class Program {
            static void Main(string[] args) {
                var items = new[] {
                    new { Code= "X", Price=0.01, DateTime="12/01/2017 08:00pm" },
                    new { Code ="Y", Price=0.02, DateTime="12/01/2017 05:40pm" },
                    new { Code ="X", Price=0.03, DateTime="12/01/2017 02:00pm" }
                };
                var newItem = new { Code = "X", Price = 0.04, DateTime = "12/01/2017 09:00pm" };
    
                var minDateTime = items.Select(x => x.DateTime).Min();
                Debug.WriteLine($"minDateTime={minDateTime}");
    
                var minItem = items.Where(x => x.DateTime == minDateTime).Single();
                Debug.WriteLine($"minItem.Price={minItem.Price}");
    
                bool withinPercent = Math.Abs(newItem.Price / minItem.Price - 1.0) < 0.1;
                Debug.WriteLine($"newItem within 10%={withinPercent}");
            }
        }
    }
