    public abstract class Brain<TValue> // TValue is the generic type parameter
    {
        protected int width;
        protected int height;
        // use TValue in the declarations
        public Dictionary<Tuple<Point, Direction>, TValue> r = new Dictionary<Tuple<Point, Direction>, TValue>();
        public abstract void Set(Point state, Direction direction, TValue reward);
        public abstract TValue Get(Point state, Direction direction);
    }
