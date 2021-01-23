    using System;
    using System.Linq;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			int n = 10;
    			Random r = new Random();
    			int[] a = new int[n];
    
    			// Generate some random numbers of different lengths
    			for (int i = 0; i < n; ++i)
    				a[i] = r.Next(Convert.ToInt32(new String('9', r.Next(1, 6))));
    
    			// Get length of longest number
    			int maxLength = a.Max(x => x.ToString().Length);
    
    			// Create array to store padded numbers
    			string[] l = new string[n];
    
    			// Get right zero padded numbers
    			for (int i = 0; i < n; ++i)
    				l[i] = a[i].ToString().PadRight(maxLength, '0');
    
    			// Print numbers
    			for (int i = 0; i < n; ++i)
    				Console.WriteLine(l[i]);
    
    			// Wait for key-press
    			Console.WriteLine("\nPress any key...");
    			Console.ReadKey();
    		}
    	}
    }
