    class SomeOtherObject
    {
        readonly Dependent _dependent;
        public Dependent { get { return _dependent; }}
        
        public SomeOtherObject(Dependent dependent)
        {
            _dependent = dependent;
        }
        
        public void Print()
        {
            Console.WriteLine(_dependent.Main.Property);
        }
    }
