    for (int y = 0; y < map.height; y++)
				{
					string line = lines[y].Replace(" ", "");
					
					
					for (int x = 0; x < map.width;x++)
					{
						map.Matrix[x,y] = Convert.ToByte(line[x]);
						if (line[x] == '#')
						{
							map.Matrix[x, y] = 1;
						}
						if (line[x] == '.')
						{
							map.Matrix[x, y] = 2;
						}
						if (line[x] == 'S')
						{
							map.Matrix[x, y] = 3;
						}
						if (line[x] == 'F')
						{
							map.Matrix[x, y] = 5;
						}
					}
				}
