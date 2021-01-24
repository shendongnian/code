    public static class ArrayExtensions
    {
        public static IEnumerable<T> GetRow<T>(this T[,] array, int rowIndex)
        {
            int columnsCount = array.GetLength(1);
            for (int colIndex = 0; colIndex < columnsCount; colIndex++)
                yield return array[rowIndex, colIndex];
        }
    }
