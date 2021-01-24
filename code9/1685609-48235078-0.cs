    public class Values
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void Add(Values other)
        {
            X += other.X;
            Y += other.Y;
        }
    }
