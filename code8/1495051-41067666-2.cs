    public static void F()
    {
        String x = "original value";
        FByValue(x);
        Console.WriteLine(x);
        FByReference(ref x);
        Console.WriteLine(x);
    }
    public static void FByValue(String s)
    {
        s = "different value for local copy of parameter only";
    }
    public static void FByReference(ref String s)
    {
        s = "different value for caller's copy, thanks to ref keyword";
    }
