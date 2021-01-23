        List<string> names = new List<string>();
        Console.WriteLine("Type in 0 to end.");
        while (true)
        {
            var typedName = Console.ReadLine();
            if (typedName.Equals("0"))
            {
                break;
            }
            names.Add(typedName);
        }
        Console.WriteLine("Entered names : ");
        foreach(var name in names)
        {
            Console.WriteLine(name);
        }
        Console.ReadLine();
