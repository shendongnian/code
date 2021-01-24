 	public class Program
	{
		public static void Main()
		{
			var n = AskForNumberOfShirts();
			Console.WriteLine("User chose to order {0} shirts.", n);
		}
		
		public static int AskForNumberOfShirts()
		{
			while (true)
			{
				Console.WriteLine("Enter a number!");
				UserEntry entry = Console.ReadLine();
				if (!entry.IsInt)
				{
					Console.WriteLine("You entered an invalid number.");
					continue;
				}
				if (entry > 10)
				{
					Console.WriteLine("{0} is too many!!!", entry);
					continue;
				}
				return entry;
			}
		}
	}
