    public double[][] Data { get; set; }
    public Matrix(int rowCount, int columnCount)
    {
        Data = new double[rowCount][];
        for (int i = 0; i < rowCount; i++)
        {
            Data[i] = new double[columnCount];
        }
    }
