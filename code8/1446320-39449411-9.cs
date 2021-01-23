    class Base
    {
        public string name;
        public void virtual Gun()
        {
            Trace.Log("I'm base class, i can't do anything");
        }
    }
    class Derived : Base
    {
        public override void Gun()
        {
            Consule.WriteLine("Hello i have gun");
        }
    }
    
    class Derived2 : Base
    {
        public override void Gun()
        {
            Consule.WriteLine("Hello i have 2 guns");
        }
    }
