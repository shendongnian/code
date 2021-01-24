    public static IQueryable<T> ToTypedQueryable<T>(this IEnumerable<T> source, Type theType, bool exact = false) {
        if (source == null) throw new ArgumentNullException("source");
        System.Collections.IList result = (System.Collections.IList)typeof(List<>)
            .MakeGenericType(theType)
            .GetConstructor(Type.EmptyTypes)
            .Invoke(null);
        foreach (var s in source) {
            Type t = s.GetType();
            if (t == theType) {
                result.Add(s);
            } else if (!exact && t.IsSubclassOf(theType)) {
                result.Add(s);
            }
        }
        return (IQueryable<T>)(result.AsQueryable());
    }
