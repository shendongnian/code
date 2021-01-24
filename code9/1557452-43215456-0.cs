    public static class Iterators
    {
        public static IEnumerable<T> Lazy<T>(Func<IEnumerable<T>> factory)
        {
            foreach (var item in factory())
                yield return item;
        }
    }
