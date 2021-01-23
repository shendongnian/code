    public class SingletonExample
    {
        private readonly DateTime _time;
        public SingletonExample(){
            _time = DateTime.Now;
        }
        public DateTime GetDateTime()
        {
            return _time;
        }
    }
