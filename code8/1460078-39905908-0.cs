    public static bool operator ==(EqualTestClass lhs, EqualTestClass rhs)
    {
        return object.Equals(lhs, rhs);
    }
    public static bool operator !=(EqualTestClass lhs, EqualTestClass rhs)
    {
        return !object.Equals(lhs, rhs);
    }
