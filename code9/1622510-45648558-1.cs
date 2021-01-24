    public static class LinqExtensions
        {
            public static IEnumerable<TSource> RemoveOne<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                var found = false;
                foreach (var item in source)
                {
                    if (!found && predicate(item))
                    {
                        found = true;
                    }
                    else
                    {
                        yield return item;
                    }
                }
            }
        }
 
