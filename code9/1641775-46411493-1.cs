    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Map<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
                yield return item;
            }
        }
    }
    // usage
    public IEnumerable<ExampleClass> GetAll(string bValue)
    {
         return repo.GetAll().Map(x => x.B = bValue);
    }
