    for(int y = 0; y < map.height; y++)
			{
		
				Console.WriteLine();
				for (int x = 0; x<map.width; x++)
				{
					if (map.Matrix[x, y] == 3)
					{
						Console.BackgroundColor = ConsoleColor.Green;
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("3");
						Console.ResetColor();
					}
					else if (map.Matrix[x, y] == 2)
					{
						Console.BackgroundColor = ConsoleColor.Blue;
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write("2");
						Console.ResetColor();
					}
					else if (map.Matrix[x, y] == 5)
					{
						Console.BackgroundColor = ConsoleColor.Green;
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("5");
						Console.ResetColor();
					}
					else if (map.Matrix[x, y] == 1)
					{
						Console.BackgroundColor = ConsoleColor.DarkRed;
						Console.ForegroundColor = ConsoleColor.DarkRed;
						Console.Write("1");
					}
					
				}
			}
