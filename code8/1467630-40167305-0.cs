	class Program
	{
	   static void Main(string[] args)
	   { 
			int sum = 1;
			int totalofSum = 0;
			while (sum <= 12)
			{
				totalofSum = sum + totalofSum;
				sum++;
			}
			Console.WriteLine(totalofSum);
			Console.ReadLine();
		}
	}
