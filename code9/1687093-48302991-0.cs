    void PrintMatrix(int[,] m)
    {
        int rows = m.GetLength(0);
        int columns = m.GetLength(1);
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < columns; c++) {
                Console.Write(m[r, c] + " ");
            }
            Console.WriteLine();
        }
    }
    int[,] TransposeMatrix(int[,] m)
    {
        int rows = m.GetLength(0);
        int columns = m.GetLength(1);
        int[,] transposed = new int[columns, rows];
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < columns; c++) {
                transposed[c, r] = m[r, c];
            }
        }
        return transposed;
    }
