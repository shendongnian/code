    public static class IntExtensions
    {
        public static bool WithinRange(this int value, int low, int high)
            => value >= low && value <= high;
    }
