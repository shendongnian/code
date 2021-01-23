    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            foreach (string p in args)
            {
                Console.WriteLine(p);
            }
        }
        else
        {
            Console.WriteLine("Empty input parameters");
        }
    }
