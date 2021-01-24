     List<item> items = new List<item>();
                items.Add(new item { id = 1, name = "A", CliamId = "6", ClaimValue = "Any" });
                items.Add(new item { id = 1, name = "Target", CliamId = "8", ClaimValue = "Tools" });
                items.Add(new item { id = 1, name = "Target", CliamId = "9", ClaimValue = "Compass" });
                var query = from i in items
                            group i by i.name
                            into g
                            select g;
                foreach(var item in query)
                {
                    Console.Write(string.Format("{0} ", item.Key));
                    foreach(var row in item)
                    {
                        Console.Write(string.Format("{0} ",row.ClaimValue));
                        
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            
            // end of the class
        }
        class item
        {
            public int id { get; set; }
            public string name { get; set; }
            public string CliamId { get; set; }
            public string ClaimValue { get; set; }
            // end of the calss
        }
