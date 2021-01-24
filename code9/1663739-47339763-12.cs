    static class Helper
    {
            public static IEnumerable<short> SliceRow(this short[,] array, short row)
            {
                for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
                {
                    yield return array[row, i];
                }
            }
     }
