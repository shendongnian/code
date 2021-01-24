    using System.IO;
    Console.Write("Please enter the path for file:");
    string lPath = Console.ReadLine();
    while(!File.Exists(lPath))
    {
        Console.Write("File has not been found. Please enter new path:");
        lPath = Console.ReadLine();
    }
    try
    {
        List<DictionaryLabels> values = csvRead(lPath);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
