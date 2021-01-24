    public static long Factorial(int n)
	{
		if (n == 0)
			return 1;
		Console.WriteLine("{0} * {1}", n, (n>1?n-1:n));
		return n * Factorial(n - 1);    
	}
	static void Main(string[] args)
	{
 	   long  a = Factorial(3);
        Console.WriteLine(a);
    }
