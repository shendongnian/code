    public static Func<int, int> AssignLocalFunctionToDelegate()
    {
        int factor;
        int Triple(int x) => factor * x;
        factor = 3;
        Console.WriteLine(Triple(2));
        return Triple;
    }
