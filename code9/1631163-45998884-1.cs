    public class Test
    {
        public string property { get; set; }
        public string name { get; set; }
    }
    
    public static void Main()
    {
        var items = new List<Test>()
        {
            new Test{ property = "1", name = "1" },
            new Test{ property = "1", name = "2" },
            new Test{ property = "2", name = "3" },
            new Test{ property = "2", name = "4" },
            new Test{ property = "", name = "5" },
            new Test{ property = "", name = "6" }
        };
    
        var result = items
                .GroupBy(x => x.property == "")
                .SelectMany(x =>
                    !x.Key ?
                        x.GroupBy(y => y.property).Select(y => y.ToList()).ToList() 
                        :
                        x.Select(y => new List<Test> { y }).ToList()
                    ).ToList();
    
        foreach (var res in result)
        {
            Console.WriteLine("Group " + res.First().property + ":");
            foreach (var item in res)
                Console.WriteLine(item.name);
        }
    }
