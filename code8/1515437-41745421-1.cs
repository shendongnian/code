	static void DrawCircle(char ch, int centerX, int centerY, int radius)
	{
		for(int y = 0; y < 25; y++)
		{
			for(int x = 0; x < 80; x++)
			{
				char c = ' ';
				var dX = x - centerX;
				var dY = y - centerY;
				if(dX * dX + dY * dY < (radius * radius))
				{
					c = ch;
				}
				Console.Write(c);
			}
            Console.WriteLine();
		}
	}
