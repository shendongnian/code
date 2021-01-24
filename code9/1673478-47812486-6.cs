    public struct Colour
    {
        private static Dictionary<string, int> _bindings = new Dictionary<string, int>();
        private string _key { get; set; }
    
        public static Colour Red => new Colour(nameof(Red));
        public static Colour Green => new Colour(nameof(Green));
        public static Colour Blue => new Colour(nameof(Blue));
    
        private Colour(string colour)
        {
            _key = colour;
        }
    
        public static void BindNumber(Colour colour, int value)
        {
            _bindings[colour._key] = value;
        }
    
        public static explicit operator int (Colour colour)
        {
            return _bindings.TryGetValue(colour._key, out var value) ? value : throw new ArgumentOutOfRangeException(nameof(colour));
        }
    
        public static implicit operator string (Colour colour)
        {
            return colour.ToString();
        }
    
        public static bool operator ==(Colour colour1, Colour colour2)
        {
            return colour1._key == colour2._key;
        }
    
        public static bool operator !=(Colour colour1, Colour colour2)
        {
            return colour1._key != colour2._key;
        }
    
        public static bool operator ==(Colour colour, int value)
        {
            return (int)colour == value;
        }
    
        public static bool operator !=(Colour colour, int value)
        {
            return (int)colour != value;
        }
    
        public override bool Equals(object obj)
        {
            return ((Colour)obj)._key == _key;
        }
    
        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }
    
        public override string ToString()
        {
            return _key;
        }
    }
