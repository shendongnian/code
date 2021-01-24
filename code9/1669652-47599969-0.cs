    static void Main(string[] args)
    {
        Dictionary<string, Action> files = new Dictionary<string, Action>();
        files.Add("file1", MethodForFile1);
        files.Add("file2", MethodForFile2);
        foreach (var file in files)
        {
            Action method = file.Value;
            method();
        }
    }
    private static void MethodForFile1()
    {
        Console.WriteLine("Processing file 1.");
    }
    private static void MethodForFile2()
    {
        Console.WriteLine("Processing file 2.");
    }
