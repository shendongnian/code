    public struct Pair
    {
        public int X { get; set; }
        public int Y { get; set; }
    
        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }
    
        public override bool Equals(object other)
        {
            var otherPair = other as Pair?;
            return otherPair != null && otherPair.Value.X == X && otherPair.Value.Y == Y;
        }
    
        public override int GetHashCode()
        {
            return (17 + X.GetHashCode()) * 23 + Y.GetHashCode();
        }
    }
