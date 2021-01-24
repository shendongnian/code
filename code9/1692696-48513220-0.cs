    static void Main(string[] args)
    {
        List<string> allLines = System.IO.File.ReadAllLines(@"C:\...").ToList();
    
        for (int i=0;i<=allLines.Length;++i)
        {
            if (i==483)
            allLines[483] = '0';
        }
    ...
    //write to new file
    }
