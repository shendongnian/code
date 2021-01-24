    class Base
    {
        public virtual int GetInt()
        {
            return 10;
        }
    }
    
    class Derived : Base
    {
        public new int GetInt()
        {
            return 11;
        }
    }
