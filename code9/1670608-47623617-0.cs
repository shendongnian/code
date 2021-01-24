    class MainClass
	{
		public static void Main (string[] args)
		{
			int counter = 1;
			
			do {
				for (int i = 0; i < counter; i++) {
					Console.Write("*");
				}
				Console.WriteLine(); // for newline
				counter++;   // increase counter
			} while (counter < 6);
		}
	}
