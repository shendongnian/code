	public class Program
	{
		public static void Main()
		{
			int width = 10;
			int height = 10;
			
			char[,] playerBoard = new char[width, height];
			int[,] numberedBoard = new int[width, height];
			
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					// Fill the numbered board with 1 to 100
					numberedBoard[x, y] = x * width + y + 1;
					
					// And the player board with emptyness
					playerBoard[x, y] = ' ';
				}
			}
			
			System.Console.WriteLine("Number at x = 3 / y = 5: " + numberedBoard[3, 5]);
			System.Console.WriteLine("Current owner of x = 3 / y = 5: \"" + playerBoard[3, 5] + "\"");
			
			// Let's change the owner of x = 3 and y = 5
			playerBoard[3, 5] = 'X';
			
			System.Console.WriteLine("New owner of x = 3 / y = 5: \"" + playerBoard[3, 5] + "\"");
		}
	}
