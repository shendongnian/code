        int rowLength = grid.GetLength(0);
        int colLength = grid.GetLength(1);
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                Console.Write(string.Format("{0} ", grid[i, j]));
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
