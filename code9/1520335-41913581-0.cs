    static void CalculateChange(int change, int[] coins)
    {
        Console.Write(change + " = ");
        int j = 0;
        while (change > 0)
        {
            for (int i = j; i < coins.Length; i++)
            {
                int coin = coins[i];
                if (coin <= change)
                {
                    change = change - coin;
                    j = i; // remmeber the position of the biggest possible coin, to start from next loop
                    Console.Write(coin + " ");
                    break;
                }
            }
        }
    }
    
