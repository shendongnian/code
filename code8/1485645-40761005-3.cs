        for (int row = 0; row < r; row++)
        {
            for (int col = 0; col < c; col++)
            {
                if (col == 0)
                {
                    matrix[row, col] = 0;
                }
                else
                {
                    Console.Write("Enter value for matrix[{0},{1}] = ", row, col);
                    matrix[row, col] = (int)Convert.ToInt32(Console.ReadLine());
                }
            }
        }
