    class Inner
    {
        public static string Increment(ref int count)
        {
            while (true)
            {
                int original = count;
                int next = original;
                if (next > 1000)
                {
                    next = 0;
                }
                next++;
                if (Interlocked.CompareExchange(ref count, next, original) == original)
                {
                    return next.ToString();
                }
            }
        }
    }
