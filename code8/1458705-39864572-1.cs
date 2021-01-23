	class MainClass
	{
		public static void Main(string[] args)
		{
			var settings = new MySetting();
			Console.WriteLine(settings.Stack); // Default value
			settings.Stack = "Not Overflowing"; // Assign new value
			settings.Save(); // Persist the setting's changes
			var settings2 = new MySetting(); // ReLoad persisted values
			Console.WriteLine(settings2.Stack);
			var settings3 = new MySetting(); // Reset values back to their defaults
			settings3.Reset();
			Console.WriteLine(settings3.Stack);
		}
	}
