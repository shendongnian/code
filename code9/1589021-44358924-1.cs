    {
        Console.Write("Enter Path: ");
        Linktopaths = Console.ReadLine();
        var informtations = System.IO.File.ReadAllLines(Linktopaths);
        foreach(var path in informtations) {
            System.IO.Directory.CreateDirectory(path);
        }
    }
