    public static List<T> LoadDataAll<T>(DataSet ds) where T : new()
    {
. . .
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            T type = new T();
            foreach (var prop in type.GetType().GetProperties())
            {
