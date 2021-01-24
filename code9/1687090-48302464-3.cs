        const int ROWS = 3;
        const int COLS = 2;
        //first matrix
        int[,] matrix1 = new int[ROWS, COLS];
        for (int row = 0; row < ROWS; row++)
        {
            for (int column = 0; column < COLS; column ++)
            {
                Console.Write("Enter num: ");
                matrix1[row, column] = int.Parse(Console.ReadLine());
            }
        }
