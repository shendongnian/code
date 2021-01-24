        public static double calTotal(double sal)
        {
            double value = 0;
            if (sal > 1000 && sal <= 3000)
            {
                value = (0.15 * sal);
            }
            if (sal > 3000)
            {
                value = (0.28 * sal);
            }
            return value;
        }
