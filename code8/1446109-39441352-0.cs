     static void Main(string[] args)
            {
                var items = Enumerable.Range(0, 10).Select(p => new { Name = "Name" + p%2, LasetName = "LN"+p%2, Dialect = "D"+p });
    
                var data = from item in items
                           group item by item.Name into g
                           select new
                           {
                               Name = g.Key,
                               LastName = g.First().LasetName,
                               Dialect = string.Join(",", g.Select(d=>d.Dialect))
                           }
                           ;
                foreach (var item in data)
                {
                    Console.WriteLine($"Name:{item.Name}, Dialect:{item.Dialect}");
                }
                Console.WriteLine("Done");
                Console.ReadLine();
            }
