    class Program
    {  
        static void Main(string[] args)
        { 
            int sum = 0;
            int i = 1;
			while (i <= 12)
			{
				sum = sum + i;
				i = i + 1;
			}
			
			Console.WriteLine(sum);			
			Console.ReadLine();        
        }
    }
