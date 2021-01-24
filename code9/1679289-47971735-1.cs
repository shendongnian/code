    private static List<int[,]> getNeigbores(int[,] matrix, int row, int column)
        {
            List<int[,]> result = new List<int[,]>();
            int rowMinimum = row - 1 < 0 ? row : row - 1;
            int rowMaximum = row + 1 > matrix.GetLength(0) ? row : row + 1;
            int columnMinimum = column - 1 < 0 ? column : column - 1;
            int columnMaximum = column + 1 > matrix.GetLength(1) ? column : column + 1;
            for (int i = rowMinimum; i <= rowMaximum; i++)
                for (int j = columnMinimum; j <= columnMaximum; j++)
                    if (i != row || j != column)
                        result.Add(new int[1, 2] { { i, j } });
            return result;
        }
