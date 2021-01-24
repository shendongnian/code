    public static class EnumerableExtensions {
        public static IWhen<T> When<T>(this IEnumerable<T> source, Func<T, bool> test) {
            var matched = source.Where(test);//Can be acted on.
            var unmatched = source.Except(matched);//To be passed down the chain
            var temp = new When<T>(matched, unmatched);
            return temp;
        }
    }
