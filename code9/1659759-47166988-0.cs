    public static class Extension
    {
        public static double Convert(this double d)
        {
            var d1 = (int)(d * 10000);
            var d2 = (int)(d * 1000) * 10;
            if ((d1 - d2) != 0)
            {
                return Math.Round(d, 4) + 0.0001;
            }
            return Math.Round(d, 4);
        }
    }
