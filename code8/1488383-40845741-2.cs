    public static void Main()
    {
        int sum = 0;
        for (long i = 2; i < 100; i++)
        {
            for(int temp = i; temp > 0; temp /= 10)
            {
                int digit = temp % 10;
                sum += Math.Pow(digit,4);
            }
            sum = 0;
            Console.WriteLine("i = {0}, sum = {1}", i, sum);
        }
    }
