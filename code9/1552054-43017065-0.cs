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
                var firstlist = new List<First>
                {
                    new First { Id = 1, Value = 2 },
                    new First { Id = 1, Value = 5 },
                    new First { Id = 1, Value = 0 }
                };
    
                var secondlist = new List<Second>
                {
                    new Second { Id = 1, Value = 2 },
                    new Second { Id = 1, Value = 3 },
                    new Second { Id = 1, Value = 4 }
                };
    
                bool common = firstlist.Select(f => f)
                                       .Any(u => secondlist.Select(x => x.Value)
                                       .Contains(u.Value));
    
                Console.WriteLine(common);        
            }
        }
