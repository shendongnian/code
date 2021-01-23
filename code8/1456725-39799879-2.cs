    static void Main(string[] args) 
    {
        if(args.Length > 0)
        {
            Console.WriteLine("First Name is " + args[0]);
            Console.WriteLine("Last Name is " + args[1]);
        }
        else
            Console.WriteLine("No Command Line Arguments were passed");
        
        Console.ReadLine();
    }
