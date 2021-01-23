    public static long GetPadovan(int n)
    {
        if (n == 0 || n == 1 || n == 2) return 1;
    
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
