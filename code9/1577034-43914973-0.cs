    public static class StringListExtensions
    {
        public static StringList<T> ToStringList<T>(this IEnumerable<T> elements)
        {
            return new StringList<T>();
        }
    }
    MyProp = SomeListArray.Select(s => $"{s}_test").ToStringList();
