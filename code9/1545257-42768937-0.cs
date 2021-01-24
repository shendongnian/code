    public class Foo
    {
        private readonly int X;
        private int Y { get; }
        internal int Z { get; private set; }
        
        public int W { get; set; }
        public Foo()
        {
            X = Y = Z = 10;
        }
    }
