    [ProtoContract]
    public struct DynamicTypeSurrogate<T>
    {
        [ProtoMember(1, DynamicType = true)]
        public T Value { get; set; }
    }
    public static class DynamicTypeSurrogateExtensions
    {
        public static List<DynamicTypeSurrogate<T>> ToSurrogateList<T>(this IList<T> list)
        {
            if (list == null)
                return null;
            return list.Select(i => new DynamicTypeSurrogate<T> { Value = i }).ToList();
        }
        public static List<T> FromSurrogateList<T>(this IList<DynamicTypeSurrogate<T>> list)
        {
            if (list == null)
                return null;
            return list.Select(i => i.Value).ToList();
        }
    }
