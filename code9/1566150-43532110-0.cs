    private static void Main()
    {
        var gridSize = GetIntFromUser("Enter the size of the grid: ");
            
        // Ensure the grid size is between 1 and the window width
        gridSize = Math.Min(Console.WindowWidth - 1, Math.Max(1, gridSize));
        var grid = new bool[gridSize, gridSize];
        var centerRow = grid.GetUpperBound(0) / 2;
        var centerCol = grid.GetUpperBound(1) / 2;
        // Populate our grid with a diamond pattern
        for (int rowIndex = 0; rowIndex < grid.GetLength(0); rowIndex++)
        {
            // Always fill in the center block of each row
            grid[rowIndex, centerCol] = true;
            // Determine how many blocks to fill in from
            // the center based on which row we're on
            var fillAmount = (rowIndex <= centerRow) 
                ? rowIndex 
                : grid.GetUpperBound(0) - rowIndex;
            for (int stepIndex = 1; stepIndex <= fillAmount; stepIndex++)
            {
                grid[rowIndex, centerCol - stepIndex] = true;
                grid[rowIndex, centerCol + stepIndex] = true;
            }
        }
        // Display the final grid to the console
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                Console.Write(grid[row,col]? "█" : " ");
            }
            Console.WriteLine();
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
