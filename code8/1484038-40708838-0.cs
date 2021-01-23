    private static int[,] ConvertToIntArray(string[,] strArr)
    {
        int rowCount = strArr.GetLength(dimension: 0);
        int colCount = strArr.GetLength(dimension: 1);
        int[,] result = new int[rowCount, colCount];
        for (int r = 0; r < rowCount; r++)
        {
            for (int c = 0; c < colCount; c++)
            {
                int value;
                result[r, c] = int.TryParse(strArr[r, c], out value) ? value : -1;
            }
        }
        return result;
    }
