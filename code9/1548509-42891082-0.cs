    public static double calTotal(double sal)
    {
        if (sal <= 1000)
        {
            return 0;
        }
        if (sal > 1000 && sal <= 3000)
        {
            return (0.15 * sal);
        }
        if (sal > 3000)
        {
            return (0.28 * sal);
        }
        throw new Exception ("This line of code should never be hit");
    }
    
