    static class Extensions
    {
        public static void IfNotNull<T>(Action<T> func, T arg)
            where T : class
        {
            if (arg != null)
            {
                func(arg);
            }
        }
    }
