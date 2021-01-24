    public static string test ()
    {
        string parameters = "one=aa&two=&three=aaa&four=";
        string pattern = "(?:^|&)[a-zA-Z]+=(?=&|$)";
        string replacement = "";
        Regex rgx = new Regex(pattern);
        string result = rgx.Replace(parameters, replacement);
        return result;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine(test());
    }
