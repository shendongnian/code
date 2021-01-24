        string name = Console.ReadLine();
        if (name.ToLower().Contains("no"))
        {
            Console.WriteLine("\nFine, don't put your name in");
        }
        else
        {
            Console.WriteLine("\nHello, " + name);
        }
