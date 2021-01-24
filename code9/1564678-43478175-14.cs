    private static void Main()
    {
        bool[,] field = new bool[3, 3];
        Random rnd = new Random();
        // The lower this number, the more bombs will be placed.
        // Must be greater than one, should be greater than 2. 
        // If set to '2', all cells will contain a bomb, which isn't fun.
        int bombScarcity = 10; 
        // Assign random bombs
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j] = rnd.Next(1, bombScarcity) % (bombScarcity - 1) == 0;
            }
        }
        // Show bomb locations
        Console.WriteLine("\nBomb Locations:\n");
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i, j] ? " T" : " F");
                if ((j + 1) % field.GetLength(1) == 0) Console.WriteLine();
            }
        }
        // Show bomb counts 
        Console.WriteLine("\nBomb Counts:\n");
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write($" {GetSurroundingBombCount(field, i, j)}");
                if ((j + 1) % field.GetLength(1) == 0) Console.WriteLine();
            }
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
