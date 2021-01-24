    class Program
    {
    	static void DrawPlayer(int x, int y)
    	{
    		for (int i = 0; i < y; i++)
    			Console.WriteLine();
    		for (int j = 0; j < x; j++)
    			Console.Write(' ');
    		Console.Write("\u25A0");
    	}
    
    	static void Main()
    	{
    		int playerX = 0, playerY = 0;
    		while (true)
    		{
    			DrawPlayer(playerX, playerY);
    			var keyInfo = Console.ReadKey(true);
    			switch (keyInfo.Key)
    			{
    				case ConsoleKey.W:
    					playerY--;
    					break;
    				case ConsoleKey.A:
    					playerX--;
    					break;
    				case ConsoleKey.S:
    					playerY++;
    					break;
    				case ConsoleKey.D:
    					playerX++;
    					break;
    			}
    			Console.Clear();
    		}
    	}
    }
