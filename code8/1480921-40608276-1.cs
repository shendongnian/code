        class Program
    {
        static void Main(string[] args)
        {
           
            for (int n = 100; n < 1000; n++)
                {
                    int sum = 0;
                    int num = n;
                    while (num != 0)
                    {
                        int r = num % 10;
                        sum += r;
                        num /= 10;
                    }
                    if (sum == 9)
                        Console.WriteLine(n);//.....Number whose all digit sum ==9
                }
        }
    }
