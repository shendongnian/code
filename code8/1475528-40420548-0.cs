    public static class FloatAndDoubleExt
    {
        public static bool IsApproximately(this double self, double other, double tolerance)
        {
            return Math.Abs(self - other) <= tolerance;
        }
        public static bool IsApproximately(this float self, float other, float tolerance)
        {
            return Math.Abs(self - other) <= tolerance;
        }
    }
