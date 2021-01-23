    public class Brain<T>
    {
        private readonly int width;
        private readonly int height;
        private readonly Dictionary<Tuple<Point, Direction>, T> r;
        Brain(int width, int height)
        {
            this.width = width;
            this.height = height;
            .........
            r = new Dictionary<Tuple<Point, Direction>, T>();
            
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    foreach (Direction direction in Enum.GetValues(typeof(Direction))
                    {
                        var state = new Point(i, j);
                        Set(state, direction, default(T));
                    }            
        }
    
        public void Set(Point state, Direction direction, T reward)
        {
            r[Tuple.Create(state, direction)] = reward;
        }
        public T Get(Point state, Direction direction)
        {
            return r[Tuple.Create(state, direction)];
        }
    }
