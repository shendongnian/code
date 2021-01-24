    public static class Extensions
    {
        public static bool In<T>(this T item, params T[] args)
        {
            return args.Contains(item);
        }
    }
