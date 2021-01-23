    public class Worker
    {
        private string _msg;
        public Worker<T> DoWorkA<T>(string input) where T : TypeA
        {
            _msg = input;
            return this;
        }
        public Worker<T> DoWorkB<T>(string input) where T : TypeB
        {
            _msg = input;
            return this;
        }
        public void DoWork()
        {
            Console.WriteLine(_msg);
        }
    }
