    public static double[][] dataTableToMatrix(DataTable dt)
    {
       double[][] data = new double[dt.Rows.Count][];
        for (int x = 0; x < dt.Rows.Count;x++)
        {
            var countOfNonNullValuesInRow = dt.Rows[x].Count(a => a != DBNull.Value);
            data[x] = new double[countOfNonNullValuesInRow];
            for (int y = 0; y < countOfNonNullValuesInRow; y++)
            {
                data[x][y] = Convert.ToDouble(dt.Rows[x][y]);
            }
        } 
        return data;
    }
