    public static bool operator ==(MyType x, MyType y)
    {
        if ((object)x == (object)y)
        {
            return true;
        }
        if ((object)x == null)
        {
            return false;
        }
        return x.Equals(y);
    }
