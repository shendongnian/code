    public static class IEnumerableExtensions
    {
        public static IEnumerable<TResult> MyCast<TResult>(this IEnumerable source)
        {
            var type = typeof(TResult);
            foreach (var item in source)
            {
                yield return (TResult)Convert.ChangeType(item, type);
            }
        }
    }
