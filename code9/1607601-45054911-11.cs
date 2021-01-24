    public static IEnumerable<(int Row, int Column)> CellsWithAtLeastOneNeighbourEqualTo<T>(
        this T[,] cells, T value)
    {
        for (var row = 0; row < cells.GetLength(0); row++)
        {
            for (var column = 0; column < cells.GetLength(1); column++)
            {
                if (GetNeighbouringCells((row, column), cells).Any(c => c.Equals(value)))
                {
                    yield return (row, column);
                }
            }
        }
    }
