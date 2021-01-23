    public static BigInteger GetPadovan(int n)
    {
        if (n == 0 || n == 1 || n == 2) return 1;
    
        BigInteger padovan = 0;
    
        if (n <= 156)
        {
            padovan = new BigInteger(GetSmallPadovan(n));
        }
    
        if (n > 156)
        {
            var prev1 = new BigInteger(8125799229398355841);
            var prev2 = new BigInteger(6133984358677405281);
            var prev3 = new BigInteger(4630407797472116077);
    
            for (var i = 156; i < n; i++)
            {
                padovan = prev2 + prev3;
                prev3 = prev2;
                prev2 = prev1;
                prev1 = padovan;
            }
        }
    
        return padovan;
    }
    
    public static long GetSmallPadovan(int n)
    {
        if (n == 0 || n == 1 || n == 2) return 1;
        if (n > 156) return 0;
    
        long padovan = 0, prev1 = 1, prev2 = 1, prev3 = 1;
    
        if (n > 2)
        {
            for (var i = 2; i < n; i++)
            {
                padovan = prev2 + prev3;
                prev3 = prev2;
                prev2 = prev1;
                prev1 = padovan;
            }
        }
        else if (n < 0)
        {
            for (var i = 0; i > n; i--)
            {
                padovan = prev3 - prev1;
                prev3 = prev2;
                prev2 = prev1;
                prev1 = padovan;
            }
        }
    
        return padovan;
    }
    
    static public long GetPadovanRecursive(int n, long prev1 = 1, long prev2 = 1, long prev3 = 1)
    {
        if (n < 0 || n > 156) return 0;
        if (n == 0 || n == 1 || n == 2) return prev1;
        return GetPadovanRecursive(--n, prev2 + prev3, prev1, prev2);
    }
    
    static public long GetPadovanSlowRecursive(int n)
    {
        if (n == 0 || n == 1 || n == 2) return 1;
        if (n < 0 || n > 156) return 0;
        return GetPadovanSlowRecursive(n - 2) + GetPadovanSlowRecursive(n - 3);
    }
