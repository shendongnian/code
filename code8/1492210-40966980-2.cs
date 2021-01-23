	public static void Main()
	{
		double root5 = Math.Sqrt(5);
		double phi = (1 + root5) / 2;
		
		int input;
        Console.Write("Enter a number : ");
        input = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Fibonacci numbers to {0}: ", input);
        
        int n=0;
        int  Fn;
        do
        {
        	Fn = (int)((Math.Pow(phi,n) - Math.Pow(-phi, -n)) / (2 * phi - 1 ));
        	Console.Write("{0} ", Fn);
        	++n;
        } while(Fn < input);
	}
