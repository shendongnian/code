    private double[][] resizeArray(double[][] matrixToResize,
                                   int maxRow, int maxColumn)
    {
        Array.Resize(ref matrixToResize, maxRow);
        for (int i = 0; i < matrixToResize.Length; i++)
        {
            Array.Resize(ref matrixToResize[i], maxColumn);
        }
        return matrixToResize;
    }
    private void resizeArrayList(List<double[][]> csvList, Dimension dimension)
    {
        csvList = csvList
            .Select(matrix => 
                resizeArray(matrix, dimension.Max_Rows, dimension.Max_Columns))
            .ToList();
    }
