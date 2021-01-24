    public struct Colour
    {
        private static Dictionary<string, int> _bindings = new Dictionary<string, int>();
        private string _key { get; set; }
    
        public static Colour Red => new Colour(nameof(Red));
        public static Colour Green => new Colour(nameof(Green));
        public static Colour Blue => new Colour(nameof(Blue));
    
        public Colour(string colour)
        {
            _key = colour;
        }
    
        public static void BindNumber(Colour colour, int value)
        {
            _bindings[colour._key] = value;
        }
    
        public static explicit operator int (Colour colour)
        {
            return GetBinding(colour._key);
        }
    
        public static implicit operator string (Colour colour)
        {
            return colour.ToString();
        }
    
        public override string ToString()
        {
            return _key;
        }
    
        private static int GetBinding(string colour)
        {
            return _bindings.TryGetValue(colour, out var value) ? value : throw new ArgumentOutOfRangeException(nameof(colour));
        }
    }
