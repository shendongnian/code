    class Base
    {
        public string name;
        public void Gun()
        {
            Trace.Log("I'm base class, i can't do anything");
        }
    }
    class Derived : Base
    {
        public void Gun()
        {
            Consule.WriteLine("Hello i have gun");
        }
    }
    
    class Derived2 : Base
    {
        public void Gun()
        {
            Consule.WriteLine("Hello i have 2 guns");
        }
    }
