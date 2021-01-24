    public static void FillDiamond(bool[,] matrix)
    {
        var count = 1;
        for (var line = 0; line < matrix.GetLength(1) / 2; line++)
        {
            FillLine(line, count, matrix);
            count += 2;
        }
        FillLine(matrix.GetLength(1) / 2, count, matrix);
        count = 1;
        for (var line = matrix.GetLength(1) - 1; line > matrix.GetLength(1) / 2; line--)
        {
            FillLine(line, count, matrix);
            count += 2;
        }
    }
