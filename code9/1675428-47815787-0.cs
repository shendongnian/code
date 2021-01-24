    public static class EX
    {
        public static void Destruct<T>(this T[] items, out T t0)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
        }
        public static void Destruct<T>(this T[] items, out T t0, out T t1)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
        }
    }
