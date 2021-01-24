    static Func<int, int> abs = i => i > 0 ? i : -i;
    public static int hash(string param)
    {
        return abs(param.GetHashCode());
    }
