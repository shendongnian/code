    public class YourClass
    { 
        public YourClass()
        {
            _rnd = new Random();
            _myNum = rnd.Next(1,13);
        }
        private Random _rnd
        private int _myNum;
        public String MyNumber
        {
            get { return _myNum };
            private set;
        }
    }
