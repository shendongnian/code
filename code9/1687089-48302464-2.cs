        Console.WriteLine("Tweede matrix: ");
        int[,] matrix2 = new int[COLS, ROWS];
        for (int row = 0; row < ROWS; row++)
        {
            for (int column = 0; column < COLS; column++)
            {
                matrix2[column, row] = matrix1[column, row];
                Console.Write(matrix2[column, row] + " ");
            }
            Console.WriteLine(" ");
        }
