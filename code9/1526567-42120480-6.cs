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
        IQueryable<Part> preparedQuery;
        test6(query, out preparedQuery);  // results are output into preparedQuery
        foreach (var res in preparedQuery)
        {
            Console.WriteLine("Result=" + res.Id);
        }
    }
    public static void test6(IQueryable<Part> origQuery, out IQueryable<Part> preparedQuery)
    {
        List<int> projectPartIds = new List<int> { 1, 2, 3 };
        var queryList = origQuery.ToList(); // convert to list to get a working Contains
        preparedQuery = (from part in queryList
                where projectPartIds.Contains(part.Id)
                select part).AsQueryable();
    }
