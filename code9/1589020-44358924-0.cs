    {
        Console.Write("Enter Path: ");
        Linktopaths = Console.ReadLine();
        var informtations = System.IO.File.ReadAllLines(Linktopaths);
        if(informtations.Length > 0) {
            System.IO.Directory.CreateDirectory(informtations[0]);
        }
    }
