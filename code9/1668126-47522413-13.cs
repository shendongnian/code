	public class Program
	{
		private const int MaximumOrder = 10;
		
		public static void Main()
		{
			var n = AskForNumberOfShirts();
			Console.WriteLine("OK, I'll order {0} shirts.", n);
		}
		
		public static int AskForNumberOfShirts()
		{
			while (true)
			{
				Console.WriteLine("Enter the number of shirts to order:");
				UserEntry entry = Console.ReadLine();
				if (!entry.IsInt)
				{
					Console.WriteLine("You entered an invalid number.");
					continue;
				}
				if (entry > MaximumOrder)
				{
					Console.WriteLine("{0} is too many! Please enter {1} or fewer.", entry, MaximumOrder);
					continue;
				}
				return entry;
			}
		}
	}
