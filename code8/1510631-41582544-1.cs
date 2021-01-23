    public static class MultidimensionalIntArrayExtensions
    {
        // Approach 1 (using Select and Sum):
        public static int[] RowSums(this int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            return Enumerable.Range(0, rows)
                .Select(row => Enumerable
                    .Range(0, cols)
                    .Select(col => arr[row, col])
                    .Sum())
                .ToArray();
        }
        // Approach 2 (using Aggregate):
        public static int[] RowSums(this int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            return Enumerable.Range(0, rows)
                .Select(row => Enumerable
                    .Range(0, cols)
                    .Aggregate(0, (a, b) => a + arr[row, b]))
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
