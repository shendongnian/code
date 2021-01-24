    public int SaveHashCode<T>(T x)
    {
        if (EqualityComparer<T>.Default.Equals(x, default(T)))
            return 0;
        IEnumerable<object> xEnumerable = x as IEnumerable<object>;
        if (xEnumerable != null)
             return xEnumerable.Aggregate(17, (acc, item) => acc * 19 + SaveHashCode(item));
        return x.GetHashCode();
    }
