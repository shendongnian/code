    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("starting");
            throw new Exception("Testing");
            Console.WriteLine("unreachable");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
