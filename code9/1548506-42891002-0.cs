    public static double calTotal(double sal)
        {
            if (sal > 1000 && sal <= 3000)
            {
                return (0.15 * sal);
            }
            else if (sal > 3000)
            {
                return (0.28 * sal);
            }
            return 0;
        }
