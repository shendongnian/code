    public class Base
    {
        // This constructor was added to avoid calling twice ConstructXY
        public Base((X x, Y y) tuple) :
            this (tuple.x, tuple.y)
        {
            
        }
        public Base(X x, Y y)
        {
            this.x = x;
            this.y = y;
        }
        public X x { get; }
        public Y y { get; }
    }
    public class Derive : Base
    {
        public Derive(Z z, Q q) : base(ConstructXY(z, q))
        {
        }
        private static (X x, Y y) ConstructXY(Z z, Q q)
        {
            X x;
            Y y;
            
            //Advanced logic for creating an X and a Y
            if (q.something == 5)
            {
                x = new X(5);
            }
            else
            {
                x = new X(25);
            }
            if (x.something == 25 && q == 9)
            {
                y = new Y(1);
            }
            else
            {
                y = new Y(5)
            }
            return (x, y);
        }
    }
