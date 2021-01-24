    static void Main()
    {
        var lst = Enumerable.Range(0, 10).ToArray();
        Console.WriteLine(string.Join(",", lst));
        var base64 = IntsToBase64(lst);
        Console.WriteLine(base64);
        var ret = Base64ToInts(base64);
        Console.WriteLine(string.Join(",", ret));
    }
