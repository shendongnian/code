    public class Entity
    {
        public IEnumerable<Entity> SubEntities { get; set; }
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> SomeBuiltInFunc<T>(this IEnumerable<T> enumerable, T item)
        {
            var list = enumerable.ToList();
            list.Add(item);
            return list;
        }
    }
