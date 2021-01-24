    private static bool IsCaseOk(char a, char b) 
    {
        return (a == 'A' && b == 'B') || (a == 'D' && b == '\0'); // any logic here
    }
    public static void Main() 
    {
        (char letterA, char letterB) _test = ('A', 'B');
        Console.WriteLine($"Letter A: '{_test.letterA}', Letter B: '{_test.letterB}'");
        if (IsCaseOk(_test.letterA, _test.letterB)) {
            Console.WriteLine("Case ok.");
        } else {
            Console.WriteLine("Case not ok.");
        }
    }
