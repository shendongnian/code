    public class X
    {
        public int Value1 { get; set; }
    
        public void DoStuff()
        {
            Y y = new Y(this);
            y.DoChildStuff();
        }
    }
    
    public class Y
    {
        public class Y(X parent)
        {
             Parent = parent;
        }
    
        public X Parent { get; }
    
        public void DoChildStuff()
        {
             // Do some stuff with Parent
        }
    }
