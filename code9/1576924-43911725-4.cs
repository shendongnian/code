    public class ColorString
    {
        private readonly string _value;
        public static ColorString DarkRed = new ColorString("Dark bed");
        public static ColorString LightBlue = new ColorString("Light blue");
        private ColorString(string value)
        {
            _value = value;
        }
        public override string ToString()
        {
            return _value;
        }
    }
