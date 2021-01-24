    public class Maybe<T> where T : class
    {
        public readonly T Value { get; }
        public Maybe(T value)
        {
            _Value = value;
        }
        public bool HasValue => _Value != null;
        public bool HasNoValue => _Value == null;
        public static operation Maybe<T>(T value) => new Maybe(value);
    }
