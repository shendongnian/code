    static class extention
        {
            public static bool EqualDouble(this double value1, double value2)
            {
                return Math.Abs(value1 - value2) < 0.0000001; 
            }
        }
