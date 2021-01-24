    var s = "DATE,		VERSION				AUTHOR		COMMENTS";
            
    Console.WriteLine(CountTabs(s,"DATE","VERSION"));
    Console.WriteLine(CountTabs(s,"VERSION","AUTHOR"));
    Console.WriteLine(CountTabs(s,"AUTHOR","COMMENTS"));
        
    public static int CountTabs(string source, string fromVal, string toVal)
    {
        int startIdx = source.IndexOf(fromVal);
        int endIdx = source.IndexOf(toVal);
            
        return source.Skip(startIdx).Take(endIdx - startIdx).Count(c => c == '\t');
    }
