        List<string> names = new List<string>();
        Console.WriteLine("Type in 0 to end.");
        bool over = false;
        while (over != true)
        {
            var typedName = Console.ReadLine();
            if (typedName == "0")
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
