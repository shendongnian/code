    static void Print(int[,] switched)
    {
        for (var y = 0; y < switched.GetLength(0); y++)
        {
            for (var x = 0; x < switched.GetLength(1); x++)
                Console.Write(switched[y, x]);
            Console.WriteLine();
        }
    }
