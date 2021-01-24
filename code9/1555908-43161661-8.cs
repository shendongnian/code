    static void Main()
    {
        int[,] map = new int[9, 9];
        var blocks = new Dictionary<int, List<int>>();
        var rows = new Dictionary<int, List<int>>();
        var columns = new Dictionary<int, List<int>>();
        // initialize lists of available numbers
        for (int i = 0; i < 9; i++)
        {
            blocks.Add(i, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            rows.Add(i, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            columns.Add(i, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }
        Random rnd = new Random();
        int failCount = 0;
        // For each row
        for (int row = 0; row < 9; row++)
        {
            // For each column in this row
            for (int column = 0; column < 9; column++)
            {
                // Calculate block based on current row and column
                int block = ((row / 3) * 3) + (column / 3);
                // Get set of available numbers for this cell by getting the intersection
                // of available numbers for the row, column, and block
                var availableItems = 
                    rows[row].Intersect(
                        columns[column].Intersect(
                            blocks[block])).ToList();
                // If we reach a point where there are no availableItems, then this is
                // not a valid Sudoku pattern. Reset everything and try again
                if (availableItems.Count == 0)
                {
                    failCount++;
                    Console.WriteLine($"Failed {failCount} times. Trying again...");
                    // Reset to the first cell
                    row = 0;
                    column = 0;
                    block = 0;
                    // Initialize data
                    for (int i = 0; i < 9; i++)
                    {
                        blocks[i] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        rows[i] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        columns[i] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    }
                    availableItems = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                }
                // Grab a number from the available numbers by choosing a random index
                var randomNumber = availableItems[rnd.Next(0, availableItems.Count)];
                    
                // Update our map with this item
                map[row, column] = randomNumber;
                // Remove this item from our lists
                rows[row].Remove(randomNumber);
                columns[column].Remove(randomNumber);
                blocks[block].Remove(randomNumber);
            }
        }
        // Print our Sudoku map:
        Console.WriteLine(new string('-', 25));
        for(int i = 0; i < 9; i++)
        {
            Console.Write("|");
            for (int j = 0; j < 9; j++)
            {
                Console.Write($" {map[i, j]}");
                if ((j + 1) % 3 == 0) Console.Write(" |");
            }
            Console.WriteLine();
            if ((i + 1) % 3 == 0) Console.WriteLine(new string('-', 25));
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
