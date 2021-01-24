    public class Derive : Base
    {
        public Derive(Z z, Q q)
            : base(ConstructX(q), ConstructY(q, z))
        { }
        private static X ConstructX(Q q)
        {
            if (q.something == 5)
                return new X(28);
            else
                return new X(25);
        }
        private static Y ConstructY(Q q, Z z)
        {
            if (z.something == 25 && q.something == 9)
                return new Y(1);
            else
                return new Y(5);
        }
    }
