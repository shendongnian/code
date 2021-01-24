    static void Main(string[] args)
    {
        Console.WriteLine(Test("hello world"));
    }
    private static int Test(dynamic value)
    {
        var chars = Chars(value.ToString());
        //foreach (var c in chars)
        //        Console.WriteLine(c);
        return ((IEnumerable<char>)chars).Count();
    }
    
    private static IEnumerable<char> Chars(string str)
    {
        return str.Distinct();
    }
