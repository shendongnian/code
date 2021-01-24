    public class Derive : Base
    {
        private Derive(X x, Y y)
            : base(x, y)
        { }
        public static Derive Create(Z z, Q q)
        {
            // here you can use your original logic to calculate X and Y
            X x = …
            Y y = …
    
            return new Derive(x, y);
        }
    }
