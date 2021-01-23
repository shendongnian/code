    class Pair : IEquatable<Pair>
    {
        public int FirstDie { get; set; }
        public int SecondDie { get; set; }
        public Pair(int d1, int d2)
        {
            FirstDie = d1;
            SecondDie = d2;
        }
        public bool Equals(Pair other)
        {
            return this.FirstDie.Equals(other.FirstDie) 
                && this.SecondDie.Equals(other.SecondDie);
        }
        public override int GetHashCode()
        {
            return FirstDie.GetHashCode() 
                    ^ SecondDie.GetHashCode();
        }
        private static Random r = new Random();
        public static Pair RollNewPair()
        {
            // The minimum value is inclusive, the maximum value is exclusive
            return new Pair(r.Next(1, 7), r.Next(1, 7));
        }
    }
