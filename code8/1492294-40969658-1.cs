    public static class ArrayExtensions
    {
        public static IEnumerable<T> GetRow<T>(this T[,] items, int row)
        {
            for (var i = 0; i < items.GetLength(1); i++)
            {
                yield return items[row, i];
            }
        }
    } 
