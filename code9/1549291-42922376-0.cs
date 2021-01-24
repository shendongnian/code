    static void Main(string[] args)
    {
        //....
        var a = 5;
        var b = 6;
    
        Test(out a, out b);
        Test(out _, out _);    
        //....
    }
    private static void Test(out int a, out int b)
    {
        //...
    }
