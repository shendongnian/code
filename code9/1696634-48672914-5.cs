    private static void Main()
    {
        // Our input strings, which are numbers converted to strins
        string str1 = 42.ToString();
        // The following line formats as currency ("c") then removes the currency symbol
        string str2 = 1234.56.ToString("c").Replace("$", "");
        Console.WriteLine(PrefixAndPad(str1, "FOO", '.', 10));
        Console.WriteLine(PrefixAndPad(str1, "$ ", 'x', 11));
        Console.WriteLine(PrefixAndPad(str2, "$ ", '~', 14));
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
