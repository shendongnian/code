    public struct Colour
    {
        private static Dictionary<string, int> _bindings = new Dictionary<string, int>();
    
        public string Value { get; set; }
    
        public static Colour Red => new Colour(nameof(Red));
        public static Colour Green => new Colour(nameof(Green));
        public static Colour Blue => new Colour(nameof(Blue));
    
        public Colour(string colour)
        {
            Value = colour;
        }
    
        public static void BindNumber(Colour colour, int value)
        {
            _bindings[colour.Value] = value;
        }
    
        public static explicit operator int (Colour colour)
        {
            return GetBinding(colour.Value);
        }
    
        public static implicit operator string (Colour colour)
        {
            return colour.ToString();
        }
    
        public override string ToString()
        {
            return Value;
        }
    
        private static int GetBinding(string colour)
        {
            return _bindings.TryGetValue(colour, out var value) ? value : throw new ArgumentOutOfRangeException(nameof(colour));
        }
    }
