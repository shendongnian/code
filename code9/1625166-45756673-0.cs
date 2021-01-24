    public static class EnumerableExtras
    {
        public static IEnumerable<Pair<T>> WithPrevious<T>(this IEnumerable<T> source)
            where T : class
        {
            T previous = null;
    
            foreach (var item in source)
            {
                yield return new Pair<T>(item, previous);
                previous = item;
            }
        }
    }
    public class Pair<T> where T : class
    {
        public Pair(T current, T previous)
        {
            Current = current;
            Previous = previous;
        }
    
        public T Current { get; }
        public T Previous { get; }
    }
