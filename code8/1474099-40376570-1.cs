    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Data
        {
            public string Name { get; set; }
            public int Property1  { get; set; }
            public int Property2  { get; set; }
            public int Property3  { get; set; }
            public int Property4  { get; set; }
            public int Property5  { get; set; }
            public int Property6  { get; set; }
            public int Property7  { get; set; }
            public int Property8  { get; set; }
            public int Property9  { get; set; }
            public int Property10 { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<Data> myClassList = new List<Data>
                {
                    new Data {Name = "1A", Property2 = 1, Property4 = 1, Property8 = 1, Property10 = 1},
                    new Data {Name = "1B", Property2 = 1, Property4 = 1, Property8 = 1, Property10 = 1},
                    new Data {Name = "1C", Property2 = 1, Property4 = 1, Property8 = 1, Property10 = 1},
                    new Data {Name = "2A", Property2 = 2, Property4 = 2, Property8 = 2, Property10 = 2},
                    new Data {Name = "2B", Property2 = 2, Property4 = 2, Property8 = 2, Property10 = 2},
                    new Data {Name = "2C", Property2 = 2, Property4 = 2, Property8 = 2, Property10 = 2},
                    new Data {Name = "3A", Property2 = 3, Property4 = 3, Property8 = 3, Property10 = 3},
                    new Data {Name = "3B", Property2 = 3, Property4 = 3, Property8 = 3, Property10 = 3},
                    new Data {Name = "3C", Property2 = 3, Property4 = 3, Property8 = 3, Property10 = 3},
                };
                var grouped = myClassList.GroupBy(x =>
                    Tuple.Create(x.Property2, x.Property4, x.Property8, x.Property10));
                foreach (var group in grouped)
                {
                    Console.WriteLine(string.Join(", ", group.Select(item => item.Name)));
                }
            }
        }
    }
    
