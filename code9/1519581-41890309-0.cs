    static void Main(string[] args)
    {
        Console.WriteLine("This exe is runned from another exe.");
        Console.ReadKey();
    }
    static void Main(string[] args)
    {
        string pattern = "ConsoleApplication1.exe";
        string dirPath = AppDomain.CurrentDomain.BaseDirectory;
        var files = Directory.GetFiles(dirPath, pattern, SearchOption.AllDirectories);
        if (files.Length > 0) Process.Start(files[0]);
        else Debug.WriteLine("File not found");
        Console.ReadKey();
    }
