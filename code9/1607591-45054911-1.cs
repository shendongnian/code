    private static bool IsValidCoordinate((int Row, int Column) coord, int rowCount, int columnCount)
    {
        Debug.Assert(rowCount >= 0);
        Debug.Assert(columnCount >= 0);
        if (0 > coord.Row || coord.Row >= rowCount ||
            0 > coord.Column || coord.Column >= columnCount)
            return false;
        return true;
    }
