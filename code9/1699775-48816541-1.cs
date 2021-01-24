    static void Main()
    {
        var sr = new SearchResult<Bird>();
        Console.WriteLine(IsSearchResultIFlyable(sr.GetType())
            ? "sr is SearchResult<IFlyable>"
            : "sr is Not SearchResult<IFlyable>");
    
        Console.ReadLine();
    }
    
    public static bool IsSearchResultIFlyable(Type t)
    {
        if (!t.IsGenericType) return false;
        if (t.GetGenericTypeDefinition() != typeof(SearchResult<>)) return false;
                
        var gr = t.GetGenericArguments();
        return gr.Length == 1 && typeof(IFlyable).IsAssignableFrom(gr[0]);
    }
