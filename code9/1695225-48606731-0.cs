    class a {
        private static int x;
        public static int X { get { return x; } }
        public a()
        {
            Interlocked.Increment(ref x);
        }
        ...
    }
