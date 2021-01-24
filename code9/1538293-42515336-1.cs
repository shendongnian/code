    using System;
						
	public class Program
	{
		struct BoardEntry {
			public int number;
			public char owner;
		}
		
		public static void Main()
		{
			int width = 10;
			int height = 10;
			
			BoardEntry[,] board = new BoardEntry[width, height];
			
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					// For each "cell" of the board, we create a new instance of
					// BoardEntry, holding the number for this cell and a possible ownage.
					board[x, y] = new BoardEntry() {
						number = x * width + y + 1,
						owner = ' '
					};
				}
			}
			
			// You can access each of those instances with `board[x,y].number` and `board[x,y].owner`
			
			System.Console.WriteLine("Number at x = 3 / y = 5: " + board[3, 5].number);
			System.Console.WriteLine("Current owner of x = 3 / y = 5: \"" + board[3, 5].owner + "\"");
			// Let's change the owner of x = 3 and y = 5
			board[3, 5].owner = 'X';
			System.Console.WriteLine("New owner at x = 3 / y = 5: \"" + board[3, 5].owner + "\"");
		}
	}
