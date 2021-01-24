    private static void Main()
    {
        while (true)
        {
            // Get grid size from user and keep it between 1 and the window width
            var gridSize = GetIntFromUser("Enter the size of the grid: ");
            gridSize = Math.Min(Console.WindowWidth - 1, Math.Max(1, gridSize));
            var grid = new bool[gridSize, gridSize];
            var center = (gridSize - 1) / 2;
            // Populate our grid with a diamond pattern
            for (int rowIndex = 0; rowIndex < grid.GetLength(0); rowIndex++)
            {
                // Determine number of blocks to fill based on current row
                var fillAmount = (rowIndex <= center)
                    ? rowIndex : grid.GetUpperBound(0) - rowIndex;
                for (int stepIndex = 0; stepIndex <= fillAmount; stepIndex++)
                {
                    grid[rowIndex, center - stepIndex] = true;
                    grid[rowIndex, center + stepIndex] = true;
                }
            }
            // Display the final grid to the console
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    Console.Write(grid[row, col] ? "█" : " ");
                }
                Console.WriteLine();
            }
        }
    }
