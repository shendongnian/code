    {
        Console.Write("Enter Path: ");
        Linktopaths = Console.ReadLine();
        string[] informtations = System.IO.File.ReadAllLines(Linktopaths);
        if(informtations.Length > 0) {
            System.IO.Directory.CreateDirectory(informtations[0]);
        }
    }
