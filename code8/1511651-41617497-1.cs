    public static List<List<double>> ConvertToListOfLists(double[,] array)
    {
        List<List<double>> result = new List<List<double>>();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            List<double> row = new List<double>();
            for (int j = 0; j < array.GetLength(1); j++)
            {
                row.Add(array[i, j]);
            }
            result.Add(row);
        }
        return result;
    }
