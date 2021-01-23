    public static Prediate<object> Cast<T>(Predicate<T> inner)
    {
        return new Predicate<object>(o => inner((T)o));
    }
    public static Predicate<T> And<T>(Predicate<T> p1, Predicate<T> p2)
    {
        return x => p1(x) && p2(x);
    }
