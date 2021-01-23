    public static int?[,] SortInput(int[] input, int requiredColumnCount)
    {
        // Guard conditions.
        if (input == null)
            throw new ArgumentNullException(nameof(input));
        if (input.Length < 1)
            throw new ArgumentOutOfRangeException(nameof(input));
        if (requiredColumnCount < 1)
            throw new ArgumentOutOfRangeException(nameof(requiredColumnCount));
        var inputLength = input.Length;
        // Sort the input array in ascending order.
        Array.Sort(input);
        // Dimension the output array.
        var requiredRowCount = (int)Math.Ceiling((decimal)inputLength / requiredColumnCount);
        var output = new int?[requiredRowCount, requiredColumnCount];
        // Setup variables to check for special handling of last output row.
        var lastRowIndex = output.GetUpperBound(0);
        var columnCountForLastRow = inputLength % requiredColumnCount;
        // Populate the output array.
        for (var inputIndex = 0; inputIndex < inputLength; inputIndex += requiredColumnCount)
        {
            var rowIndex = inputIndex / requiredColumnCount;
            // Special handling may be required if there are insufficient
            // input values to fully populate the last output row.
            if ((rowIndex == lastRowIndex) && (columnCountForLastRow != 0))
                requiredColumnCount = columnCountForLastRow;
            for (var columnIndex = 0; columnIndex < requiredColumnCount; columnIndex++)
            {
                output[rowIndex, columnIndex] = input[inputIndex + requiredColumnCount - columnIndex - 1];
            }
        }
        return output;
    }
