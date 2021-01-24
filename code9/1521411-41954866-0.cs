    public class BaseClass
    {
        public int a;
        public void Index()
        {
            a = 1;
        }
        public int Index1()
        {
            return a;
        }
    }
    public class DerivedClass : BaseClass
    {
        public int a;
        //some derived class mehods
        public int Index1()
        {
            return a;
        }
    }
