    public static void Main(string[] args)
    {
        test("0000000000000"); // Outputs 0
        test("0000100010000"); // Outputs 3
        test("1111111111111"); // Outputs 0
        test("1000000000001"); // Outputs 11
        test("1000000000000"); // Outputs 0
        test("0000000000001"); // Outputs 0
        test("1010101010101"); // Outputs 1
        test("1001000100001"); // Outputs 4
    }
    static void test(string s)
    {
        Console.WriteLine(CountZerosBetweenOnes(s));
    }
