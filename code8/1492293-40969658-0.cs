    public static class ArrayExtensions
    {
        public static IEnumerable<T> GetRow<T>(this T[,] items, int row)
        {
            for (var i = 0; i < 2; i++)
            {
                yield return items[row, i];
            }
        }
    } 
