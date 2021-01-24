    using System.Collections.Generic;
    
    public static class LINQExtensions
    {
        public delegate bool TryFunc<TSource, TResult>(TSource source, out TResult result);
        public static IEnumerable<TResult> SelectTry<TSource, TResult>(
            this IEnumerable<TSource> source, TryFunc<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                TResult result;
                if (selector(item, out result))
                {
                    yield return result;
                }
            }
        }
    }
