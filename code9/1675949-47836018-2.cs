    public static T[][] DeleteColumns<T>(this T[][] matrix, int[] columns)
        {
            if (matrix.Length == 0) return matrix;
            //Previous code assumed matrix could be jagged - new code assumes all columns 
            //present and all rows same length
            var rowLength = matrix[0].Length;
            if (rowLength == 0) return matrix;
            var sorted = columns.Distinct().ToArray();
            var target = new T[matrix.Length][];
            var remainingLength = rowLength - sorted.Length;
            //Allocate the targets all in one go - to avoid doing allocation in parallel.
            for (var row = 0; row < matrix.Length; row++)
            {
                target[row] = new T[remainingLength];
            }
            //Work out remaining columns (previous code assumed these could 
            //be different per row, this assumes all rows have the same
            //contents.
            var remaining = Enumerable.Range(0, rowLength).Except(sorted).ToArray();
            for (int row = 0; row < matrix.Length; row++)
            {
                var sourceRow = matrix[row];
                var targetRow = target[row];
                for (int i = 0; i < targetRow.Length; i++)
                {
                    targetRow[i] = sourceRow[remaining[i]];
                }
            }
            return target;
        }
