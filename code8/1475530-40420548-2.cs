    public static class FloatAndDoubleExt
    {
        public static bool IsApproximately(this double self, double other, double within)
        {
            return Math.Abs(self - other) <= within;
        }
        public static bool IsApproximately(this float self, float other, float within)
        {
            return Math.Abs(self - other) <= within;
        }
    }
