    private static void Main(string[] args)
    {
        string json = @"
            {
                a: 1,
                b: 2,
                c: [
                    {c1: 'asdas', c2:231},
                    {c1: 'aaaaaa', c2: 100},
                    {c1: 'x', c2: 83823}
                ]
            }
            ";
        Console.WriteLine(JObject.Parse(json)["c"].Count());
        //following also works
        Console.WriteLine(o.Property("c").Value.Count());
        //both print 3
    }
