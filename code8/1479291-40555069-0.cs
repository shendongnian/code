        int[,] grid = new int[20,20];
        while (!stopped)
        {
            string[,] coordinates = Console.ReadLine();
            string response = Console.ReadLine();
            response = response.ToUpper();
            if (response == "STOP")
                stopped = true;
            else
            {
                string[] xy = coordinates.Split(',');
                x = int.Parse(xy[0]);
                y = int.Parse(xy[1]);
                grid[x,y] = 1;
                
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (grid[i, j] > 0)
                            Console.Write("*");
                        else
                            Console.Write("#");
                    }
                    Console.WriteLine("");
                }
            }
        }
