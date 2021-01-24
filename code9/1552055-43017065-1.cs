        class First
        {
            public int Id { get; set; }
            public int Value { get; set; }
        }
    
        class Second
        {
            public int Id { get; set; }
            public int Value { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var firstList = new List<First>
                {
                    new First { Id = 1, Value = 2 },
                    new First { Id = 1, Value = 10 },
                    new First { Id = 1, Value = 0 }
                };
    
                var secondList = new List<Second>
                {
                    new Second { Id = 1, Value = 2 },
                    new Second { Id = 1, Value = 2 },
                    new Second { Id = 1, Value = 4 }
                };
    
                bool hasCommonValues = firstList.Select(f => f)
                                       .Any(u => secondList.Select(x => x.Value)
                                       .Contains(u.Value));
    
                Console.WriteLine(hasCommonValues);        
            }
        }
