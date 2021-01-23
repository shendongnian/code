    public static class MultidimensionalIntArrayExtensions
    {
        public static int[] RowSums(this int[,] arr)
        {
            return Enumerable.Range(0, arr.GetLength(0))
                .Select(row => Enumerable.Range(0, arr.GetLength(1)).Select(col => arr[row, col]).Sum())
                .ToArray();
        }
    }
    // Usage:
    int[,] arr =
    {
    	{ 1, 2, 3 },
    	{ 2, 3, 4 },
    	{ 3, 4, 5 },
    	{ 6, 7, 8 },
    	{ 1, 1, 1 }
    };
    
    int[] rowSums = arr.RowSums(); // [6, 9, 12, 21, 3]
