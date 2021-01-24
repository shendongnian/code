    [JsonConverter(typeof(EnumerationConverter<Color>))]
    public class Color : Headspring.Enumeration<Color, int>
    {
        public static readonly Color Red = new Color(1, "Red");
        public static readonly Color Blue = new Color(2, "Blue");
        public static readonly Color Green = new Color(3, "Green");
        private Color(int value, string displayName) : base(value, displayName) { }
    }
