    public static void Main()
    {
        var str = File.ReadAllText(@"C:\cmd.txt");
        var searchTerm = "IMAGE";
        var matches = Regex.Matches(str, @"\b" + searchTerm + @"\b", RegexOptions.IgnoreCase);
        Console.WriteLine(matches.Count);
        Console.ReadLine();            
    }  
