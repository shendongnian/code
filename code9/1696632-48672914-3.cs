    private static void Main()
    {
        // Our input strings, which are numbers converted to strins
        string str1 = 42.ToString();
        string str2 = 1234.56.ToString("0,000.00"); // Add the comma
        Console.WriteLine(PrefixAndPad(str1, "FOO", '.', 10));
        Console.WriteLine(PrefixAndPad(str1, "$ ", 'x', 11));
        Console.WriteLine(PrefixAndPad(str2, "$ ", '~', 14));
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
