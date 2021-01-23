    private static void Test(Dictionary<string, string> values)
    {
        ...
    }
    public static void Main(string[] args)
    {
        string myName = "John", myAge = "33", myAddress = "Melbourne";
        Test(new Dictionary<string, string> { { nameof(myName), myName }, { nameof(myAge), myAge} });
    }
