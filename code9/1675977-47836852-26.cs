    public static T[][] DeleteColumns<T>(T[][] matrix, int[] columns)
    {
        if (matrix.Length == 0) return new T[0][];
        bool[] delColumns = new bool[matrix[0].Length];
        foreach (int col in columns) delColumns[col] = true;
        List<int> remainCols = new List<int>();
        for (int i = 0; i < delColumns.Length; i++)
        {
            if (!delColumns[i]) remainCols.Add(i);
        }
        var target = new T[matrix.Length][];
        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
        {
            T[] sourceRow = matrix[rowIndex];
            T[] targetRow = new T[remainCols.Count];
            for (int i = 0; i < remainCols.Count; i++)
            {
                targetRow[i] = sourceRow[remainCols[i]];
            }
            target[rowIndex] = targetRow;    
        }
        return target;
    }
