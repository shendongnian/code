    public static class Extensions
    {
        public static int IfZero (this int value, int defaultValue)
        {
            return value == 0 ? defaultValue : value;
        }
        public static int ReplaceValue(this int value, int valueToReplace, int replaceWith)
        {
            return value == valueToReplace ? replaceWith : value;
        }
    }
