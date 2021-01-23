    public class Worker
    {
        public Worker<T> DoWorkA<T>(T value) where T : TypeA
        {
            _msg = input;
            return this;
        }
        public Worker<T> DoWorkB<T>(T value) where T : TypeB
        {
            _msg = input;
            return this;
        }
    }
