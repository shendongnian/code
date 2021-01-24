    static void Main (string[] args = null)
    {
        Console.Write("Do something with the arguments. The first item is: ");
        if(args != null)
        {
            Console.WriteLine(args.FirstOrDefault());
        }
        else
        {
            Console.WriteLine("unknown");
        }
        code();
    }
