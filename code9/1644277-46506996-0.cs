    static int numberOfCoins(int n)
    {
        if (n >= 25)
        {
            return 1 + numberOfCoins(n - 25);
        }
        else if (n >= 10)
        {
            return 1 +  numberOfCoins(n - 10);
        }
        else if (n >= 5)
        {
            return 1 +  numberOfCoins(n - 5);
        }
        else if (n > 0)
        {
            return 1 + numberOfCoins(n - 1);
        }
    
        return 0;
    }
 
