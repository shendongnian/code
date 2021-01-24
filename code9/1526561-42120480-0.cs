    public static void test4()
    {
        List<Part> query = new List<Part>();
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
