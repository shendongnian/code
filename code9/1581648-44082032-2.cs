    public double[,] Data { get; set; }
    public Matrix(int rowCount, int columnCount)
    {
        Data = new double[rowCount, columnCount];
    }
