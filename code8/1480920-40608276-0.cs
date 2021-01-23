    class Program
    {
        static void Main(string[] args)
        {
           
            for (int n = 100; n < 1000; n++)
            {
    			int sum = 0;
                while (n !=0)
                {
    				int r=n%10;
                    sum += r;
                    n /= 10;
                }
    			if (sum == 9)
                    Console.WriteLine(n);//.....Number whose all digit sum ==9
            }
        }
    }
