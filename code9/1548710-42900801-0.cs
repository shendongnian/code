    public class Base
    {
        public Base()
        {
            if (_instance == null)
                _instance = this;//record the first instance
        }
        static Base _instance;
        public virtual void foo()
        {
            if (_instance == this)
                Debug.WriteLine("Base foo()");
        }
    }
