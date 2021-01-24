	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("n = {0}", n);
        while(n != 1)
        {
            if (n % 2 == 0)
            {
            	n = n / 2;
            }
            else
            {
            	n = 3 * n + 1;
            }
            Console.WriteLine("n = {0}", a);
        }
		Console.ReadKey();
	}
