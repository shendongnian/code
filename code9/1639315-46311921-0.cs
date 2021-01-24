    public static string Filter(string s)
    {
        var regex = new Regex(@"(\d\.\d|\d,\d|[0-9a-zA-Z]|\s)+");
        var matches = regex.Matches(s);
        var sb = new StringBuilder();
        foreach (var match in matches) sb.Append(match);
        return sb.ToString();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine(Filter("7.5kg (estimate). 2,4 kilos (total?%/=\"º).,¿#@--__"));
    }
