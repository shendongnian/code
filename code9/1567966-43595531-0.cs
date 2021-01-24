    private static int pageNumber = 0;
    const int PageSize = 10;
    public static void Main()
    {
        IEnumerable<string> page;
        List<string> lines = new List<string>();
        while ((page = NextPage()).Any())
        {
            // Here I am simply throwing the contents into a List 
            // but you can show it in the DataTable
            lines = page.ToList();
    
            // Do processing
        }
            
        Console.Read();
    }
    
    private static IEnumerable<string> NextPage()
    {
        IEnumerable<string> page = File.ReadLines("Path")
            .Skip(pageNumber * PageSize).Take(PageSize);
        pageNumber++;
    
        return page;
    }
