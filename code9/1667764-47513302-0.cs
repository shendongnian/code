    public static T[,] Sort2DArray<T>(T[,] array, int column, bool ascending = true)
    {
        int i = 0;
        List<T[]> items = new List<T[]>();
        int columns = array.GetLength(1);
        int rows = array.GetLength(0);
        T[] obj = new T[columns];
        foreach (var item in array)
        {
            obj[i % columns] = item;
            if ((i + 1) % 2 == 0)
            {
                items.Add(obj);
                obj = new T[columns];
            }
            i++;
        }
        var ordered = ascending ? items.OrderBy(a => a[column]) : items.OrderByDescending(a => a[column]);
        T[,] result = new T[rows, columns];
        for (int r = 0; r < rows; r++)
        {
            var row = ordered.ElementAt(r);
            for (int c = 0; c < columns; c++)
            {
                result[r, c] = row[c];
            }
        }
        return result;
    }
