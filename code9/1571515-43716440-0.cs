    static void Main(string[] args)
    {
        var result = SplitOnCommaNotFollowedByWhiteSpace("A,B,Venus, New York 10001");
        //Result: string["A", "B", "Venus, New York"]
    }
    public static string[] SplitOnCommaNotFollowedByWhiteSpace(string input)
    {
        var regex = new Regex(@",(?!\s)", RegexOptions.IgnoreCase);
        return regex.Split(input);
    }
