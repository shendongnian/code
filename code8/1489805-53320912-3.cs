    public static class ColorExtensions
    {
        public static string ToHexString(this Color color, bool outputAlpha = true)
        {
            string DoubleToHex(double value)
            {
                return string.Format("{0:X2}", (int)(value * 255));
            }
            string hex = "#";
            if (outputAlpha) hex += DoubleToHex(color.A);
            return $"{hex}{DoubleToHex(color.R)}{DoubleToHex(color.G)}{DoubleToHex(color.B)}";
        }
    }
