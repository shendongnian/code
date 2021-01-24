    public static int add2(int a)
    {
        return 5 + Program.innerFn@5(a);
    }
    public static int add2'(int a)
    {
        return a + 2;
    }
    internal static int innerFn@5(int a)
    {
        if (a < 3)
        {
            return a + 1;
        }
        return a + 2;
    }
