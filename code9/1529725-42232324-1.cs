    static int Abs(int i)
    {
        return i > 0 ? i : -i;
    }
    public static int hash(string param)
    {
        return Abs(param.GetHashCode());
    }
