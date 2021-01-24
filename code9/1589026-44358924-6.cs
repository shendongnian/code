    Console.Write("Enter Path: ");
    Linktopaths = Console.ReadLine();
    string[] informations = System.IO.File.ReadAllLines(Linktopaths);
    foreach (string path in informations) 
    {
        System.IO.Directory.CreateDirectory(path);
    }
