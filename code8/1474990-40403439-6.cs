    private static void Test(dynamic values)
    {
        var dict = ((IDictionary<string, object>)values);
    }
    public static void Main(string[] args)
    {
        dynamic values = new ExpandoObject();
        values.A = "a";
        Test(values);
    }
