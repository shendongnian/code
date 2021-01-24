    public static int add2(int a)
    {
        return 5 + (new Program.innerFn@5()).Invoke(a);
    }
    public static int add2'(int a)
    {
        return (new Program.innerFn'@8(a)).Invoke(null);
    }
