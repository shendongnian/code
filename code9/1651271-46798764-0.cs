    static void Main(string[] args)
    {
        Console.WriteLine(GetPath());
        Console.Read();
    }
    static string GetPath([CallerFilePath]string fileName = null)
    {
        return fileName;
    }
