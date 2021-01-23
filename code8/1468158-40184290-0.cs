    class MainClass
    	{
    		public static void Main(string[] args)
    		{
    			Console.WriteLine("Hello World!");
    			string input = Console.ReadLine();
    			Console.WriteLine(input);
    
    			int num2;
    			if (int.TryParse(input, out num2))
    			{
    				Console.WriteLine(num2);
    			}
    		}
	}
