    /// <summary>
    /// Calculates row and column index from given linear index and column length.
    /// </summary>
    /// <param name="index1D">linear index</param>
    /// <param name="collength">column length</param>
    /// <param name="row">returns index of row.</param>
    /// <param name="col">returns index of column.</param>
    public static void Get2DIndex(int index1D, int collength, out int row, out int col)
    {
        row = index1D % collength;
        col = index1D / collength;
    }
