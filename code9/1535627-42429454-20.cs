    public static bool operator ==(MyType x, MyType y)
    {
        if (x == null)
        {
             return y == null;
        }
        return x.Equals(y);
    }
