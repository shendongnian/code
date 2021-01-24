    double ApplyMatrix(double[,] matrix, double[] x)
    {
        double sum = 0;
        for (int row = 0; row < matrix.GetLength(1); row++)
        {
            double rowSum = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                rowSum += matrix[col, row] * x[col];
            }
            sum += x[row] * rowSum;
        }
        return sum;
    }
