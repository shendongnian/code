    public static explicit operator bool(InterlockedBool obj)
    {
        return obj.Value;
    }
    public static explicit operator InterlockedBool(bool obj)
    {
        return new InterlockedBool(obj);
    }
