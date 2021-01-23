    static void Main(string[] args)
            {
                int player = 0;
    
                string[,] grid = new string[3, 3] {{"   ","   ","   "},
                                                   {"   ","   ","   "},
                                                   {"   ","   ","   "} };
    
    
                string box = System.IO.File.ReadAllText(@"C:\Users\..\Box.txt");
    
                Console.WriteLine(box);
                Console.ReadLine();
    
                while (true)
                {
                    Console.WriteLine("Enter Coordinate in 'x,y' Format");
                    string update = Console.ReadLine();
    
                    if (player == 0)
                    {
                        string[] coords = update.Split(',');
                        var x = int.Parse(coords[0]) - 1;
                        var y = int.Parse(coords[1]) - 1;
                        grid[x,y] = " X ";
                        player++;
                    }
                    else
                    {
                        string[] coords = update.Split(',');
                        var x = int.Parse(coords[0]) - 1;
                        var y = int.Parse(coords[1]) - 1;
                        grid[x, y] = " 0 ";
                        player--;
                    }
    
                    UpdateGrid(grid, box);
                }
    
            }
    
            public static void UpdateGrid(string[,] grid, string box)
            {
                Console.Clear();
    
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        box = box.Replace((i + 1) + "," + (j + 1), grid[i, j]);
                    }
                }
    
                // In the case not required as clearning the console default the cursor back to 0,0, but left in 
                // as an example
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(box);
            }
