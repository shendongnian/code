       public static class Masking
    {
        public static string MaskAllButLast(this string input, int charsToDisplay, char maskingChar = 'x')
        {
            int charsToMask = input.Length - charsToDisplay;
            return charsToMask > 0 ? $"{new string(maskingChar, charsToMask)}{input.Substring(charsToMask)}" : input;
        }
    }
