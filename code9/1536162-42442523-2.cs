    public static class Extensions
    {
        public static bool In<T>(this T item, params T[] args)
        {
            foreach (T arg in args)
            {
                if (arg.Equals(item))
                    return true;
            }
            return false;
        }
    }
