    static void Main(string[] args)
    {
        test5();
        Console.ReadLine();
    }
    public static void test5()
    {
        List<Part> parts = new List<Part>();
        parts.Add(new Part() { Id = 1 });
        parts.Add(new Part() { Id = 2 });
        parts.Add(new Part() { Id = 10 });
        parts.Add(new Part() { Id = 11 });
        var query = parts.AsQueryable();
        test4(ref query);
    }
    public static void test4(ref IQueryable<Part> query)
    {
    
        List<int> projectPartIds = new List<int>{ 1, 2, 3 };
        query  = from part in query
                where projectPartIds.Contains(part.Id)
                select part;
        foreach (var res in query)
        {
            Console.WriteLine("Result="+res.Id);
        }
    }
