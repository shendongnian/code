    public sealed class Rank
    {
        private static readonly List<Rank> ranks = new List<Rank>();
        // Important: these must be initialized in order.
        // (That can be avoided, but only at the cost of more code.)        
        public static Rank Kingdom { get; } = new Rank(0);
        public static Rank Phylum { get; } = new Rank(1);
        public static Rank Order { get; } = new Rank(2);
        public static Rank Family { get; } = new Rank(3);
        public static Rank Genus { get; } = new Rank(4);
        public static Rank Species { get; } = new Rank(5);
        private readonly int value;
        // TODO: Change to throw InvalidOperationException (or return null)
        // for boundaries
        public Rank Child => ranks[value + 1];
        public Rank Parent => ranks[value - 1];
        private Rank(int value)
        {
            this.value = value;
            ranks.Add(this);
        }
    }
