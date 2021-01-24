    public class Rating
    {
        public int Value { get; }
        private readonly IDictionary<string, int> _asValue = new Dictionary<string, int>
        {
            {"One", 1},
            {"Two", 2},
            {"Three", 3},
            {"Four", 4},
            {"Five", 5},
        };
        public Rating(string rating)
        {
            Value = _asValue[rating];
        }
        public override string ToString()
        {
            return _asValue.First(pair => pair.Value == Value).Key;
        }
    }
