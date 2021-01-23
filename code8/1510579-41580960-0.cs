    static void Main(string[] args)
    {
        if(args.Length == 1)
        {
            Console.WriteLine("I got this! Going to url \'{0}\'...", args[0]);
            // Doing something
            Console.WriteLine("Gotcha!");
            return;
        }
        Console.WriteLine("Hi i got nothing for you! Give me something to be useful!");
    }
