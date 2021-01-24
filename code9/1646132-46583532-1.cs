    public static class Enumerable
    {
        // many static LINQ extension methods...
    
        class WhereEnumerableIterator<TSource> : Iterator<TSource>
        {
           // ...
        }
        
        internal class EmptyEnumerable<TElement>
        {
            public static readonly TElement[] Instance = new TElement[0];
        }
    
        public class Lookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>, ILookup<TKey, TElement>
        {
            // ...
        }
        
         // many others
    }
