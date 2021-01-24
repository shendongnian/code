    {
        Console.Write("Enter Path: ");
        Linktopaths = Console.ReadLine();
        string[] informtations = System.IO.File.ReadAllLines(Linktopaths);
        foreach (string path in informtations) {
            System.IO.Directory.CreateDirectory(path);
        }
    }
