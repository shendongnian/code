    public static double[][] dataTableToMatrix(DataTable dt)
    {
       double[][] data = new double[dt.Rows.Count][];
        for (int x = 0; x < dt.Rows.Count;x++)
        {
            List<double> items = new List<double>();
            for (int y = 0; y < dt.Columns.Count; y++)
            {
                if (dt.Rows[x][y] != DBNull.Value)
                    items.Add(Convert.ToDouble(dt.Rows[x][y]));
                else
                    break;
            }
            data[x] = items.ToArray();
        } 
        return data;
    }
