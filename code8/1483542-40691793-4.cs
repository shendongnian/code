    public static class Worker
    {
        public static Worker<T> DoWorkA<T>(this T value) where T : TypeA
        {
            _msg = input;
            return this;
        }
        public static Worker<T> DoWorkB<T>(this T value) where T : TypeB
        {
            _msg = input;
            return this;
        }
    }
