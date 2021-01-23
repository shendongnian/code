    public static void F1()
    {
        String x = "original value";
        F2(ref x);
        Console.WriteLine(x);
        F3(ref x);
        Console.WriteLine(x);
    }
    public static void F2(String s)
    {
        s = "different value for local copy of parameter only";
    }
    public static void F3(ref String s)
    {
        s = "different value for caller's copy, thanks to ref keyword";
    }
