	using System;
						
	public class Program
	{
		public static void Main()
		{
			var random = new Random();
			Console.WriteLine("Hello World");
			
			for(int i = 0; i < 100; i++)
			{
				var now = DateTime.UtcNow;
				var later = now
					.AddDays(random.Next(1, 100))
					.AddHours(random.Next(1, 24));
				
				Console.WriteLine("Something later: " + later.ToString("yyyy-MM-dd HH:mm:ss"));
			}
		}
	}
