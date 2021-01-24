    public int SaveHashCode<T>(T x)
    {
        if (EqualityComparer<T>.Default.Equals(x, default(T)))
            return 0;
        var code = 17;
        IEnumerable<object> xEnumerable = x as IEnumerable<object>;
        if (xEnumerable != null)
        {
            foreach (var item in xEnumerable)
                code = 19 * code + item.GetHashCode();
            return code;
        }
        return x.GetHashCode();
    }
