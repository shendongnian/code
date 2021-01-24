    public static IEnumerable<T> GetNeighbouringCells<T>((int Row, int Column) coord, T[,] cells)
    {
        if (cells == null)
            throw new ArgumentOutOfRangeException();
        if (!IsValidCoordinate(coord, cells.GetLength(0), cells.GetLength(1)))
            throw new ArgumentOutOfRangeException();
        return GetAllNeighbouringCoordinates(coord.Row, coord.Column)
            .Where(c => IsValidCoordinate(c, cells.GetLength(0), cells.GetLength(1)))
            .Select(c => cells[c.Row, c.Column]);
    }
