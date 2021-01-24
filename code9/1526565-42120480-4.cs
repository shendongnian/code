    public static void test4()
    {
        List<Part> parts = new List<Part>();
        parts.Add(new Part() { Id = 1 });
        parts.Add(new Part() { Id = 2 });
        parts.Add(new Part() { Id = 10 });
        parts.Add(new Part() { Id = 11 });
        var query = parts.AsQueryable();
        List<int> projectPartIds = new List<int>(new []{ 1, 2, 3 });
        var results  = from part in query
                where projectPartIds.Contains(part.Id)
                select part;
        foreach (var res in results)
        {
            Console.WriteLine("Result="+res.Id);
        }
    }
    public class Part
    {
        public int Id;
    }
