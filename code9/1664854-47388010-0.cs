    public static T GetValue<T>(String csvFilePath, int row, int col)
    {
        string line = File.ReadLines(csvFilePath).Skip(row).Take(1).First();
        var x = line.Split(',');
        return (T)Convert.ChangeType(x[col-1], typeof(T));
    }
