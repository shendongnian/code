    static void Main(string[] args)
    {
        RecursiveSearch(@"C:\\Users\\foo\\Desktop\\test");
        Console.ReadKey();
    }
    
    static void RecursiveSearch(string dir)
    {
        try
        {
            foreach (string f in Directory.GetFiles(dir))
                Console.WriteLine(f);
            foreach (string d in Directory.GetDirectories(dir))
            {
                Console.WriteLine(d);
                RecursiveSearch(d);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
