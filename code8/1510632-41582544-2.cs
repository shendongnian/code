    public static class MultidimensionalIntArrayExtensions
    {
        // Approach 1 (using Select and Average)
        public static double[] RowAverages(this int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            return Enumerable.Range(0, rows)
                .Select(row => Enumerable
                    .Range(0, cols)
                    .Select(col => arr[row, col])
                    .Average())
                .ToArray();
        }
        // Approach 2 (using Aggregate)
        public static double[] RowAverages(this int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            return Enumerable.Range(0, rows)
                .Select(row => Enumerable
                    .Range(0, cols)
                    .Aggregate(0.0, (avg, col) => avg + ((double)arr[row, col] / cols)))
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
    
    double[] rowSums = arr.RowAverages(); // [2, 3, 4, 7, 1.3333]
