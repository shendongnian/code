    private static void Main()
    {
        bool[,] field = new bool[3, 3];
        Random rnd = new Random();
        // Assign random bombs
        for (int i = 0; i <= field.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= field.GetUpperBound(1); j++)
            {
                field[i, j] = rnd.Next(1, 3) % 2 == 0;
            }
        }
        // Show bomb locations
        Console.WriteLine("\nBomb Locations:\n");
        for (int i = 0; i <= field.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= field.GetUpperBound(1); j++)
            {
                Console.Write(field[i, j] ? " T" : " F");
                if ((j + 1) % field.GetLength(1) == 0) Console.WriteLine();
            }
        }
        // Show bomb counts 
        Console.WriteLine("\nBomb Counts:\n");
        for (int i = 0; i <= field.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= field.GetUpperBound(1); j++)
            {
                Console.Write($" {GetSurroundingBombCount(field, i, j)}");
                if ((j + 1) % field.GetLength(1) == 0) Console.WriteLine();
            }
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
