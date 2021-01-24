    public static class Extensions
    {
        public static bool IsExist(this Cell[,] mapCells, Cell index)
        {
            bool cellExists = index.x >= 0 &&
                   index.y >= 0 &&
                   index.x < mapCells.GetLength(0) &&
                   index.y < mapCells.GetLength(1);
            return cellExists;
        }
    }
