    public static class Converter
    {
        public static int? ConvertToInt(char value, char lowerLimit, char upperLimit)
        {
            // If the value provided is outside acceptable ranges, then just return
            // null. Note the int? signature - nullable integer. You could also swap
            // this with 0.
            if (value < lowerLimit || value > upperLimit)
                return null;
            
            // 'A' is 65. Substracting 64 gives us 1.
            return ((int)value) - 64;
        }
    
        public static char? ConvertToChar(int value, int lowerLimit, int upperLimit)
        {
            // Basically the same as above, but with char? instead of int?
            if (value < lowerLimit || value > upperLimit)
                return null;
    
            // 'A' is 65. Substracting 64 gives us 1.
            return ((char)value) + 64;
        }
    }
