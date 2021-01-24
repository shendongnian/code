    static void Main(string[] args)
    {
        var positiveInput = "\"D:\\src\\repos\\myprj\\bin\\Debug\\MyApp.exe\" /?";
        Test(positiveInput, @"[^\\]+(\.exe)");
        Test(positiveInput, @"[^\\]+(?:\.exe)");
        Test(positiveInput, @"[^\\]+(?=\.exe)");
        
        var negativeInput = "\"D:\\src\\repos\\myprj\\bin\\Debug\\MyApp.dll\" /?";
        Test(negativeInput, @"[^\\]+(?=\.exe)");
    }
    static void Test(String input, String pattern)
    {
        Console.WriteLine($"Input: {input}");
        Console.WriteLine($"Regex pattern: {pattern}");
        
        var match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
        if (match.Success)
        {
            Console.WriteLine("Matched: " + match.Value);
            for (int i = 0; i < match.Groups.Count; i++)
            {
                Console.WriteLine($"Groups[{i}]: {match.Groups[i]}");
            }
        }
        else
        {
            Console.WriteLine("No match.");
        }
        Console.WriteLine("---");
    }
