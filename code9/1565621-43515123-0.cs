    private readonly string[] Separators = new string[] { "," };
    public void YourMethod()
    {
        string result = FindSubstring("james");
        Console.WriteLine(result);
    }
    private string FindSubstring(string input)
    {
        string source = "12:13:0 james,1324,7656119796027";
        int first = source.IndexOf(input) + input.Length;
        string substring = source.Substring(first);
        string[] splittedSubstring = substring.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
        return splittedSubstring[0];
    }
