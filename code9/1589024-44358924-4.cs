    {
        Console.Write("Enter Path: ");
        Linktopaths = Console.ReadLine();
        string[] informtations = System.IO.File.ReadAllLines(Linktopaths);
        for (int i = 0; i < informtations.Length; i++) {
            string path = informtations[i];
            System.IO.Directory.CreateDirectory(path);
        }
    }
