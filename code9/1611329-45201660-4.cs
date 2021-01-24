    public static T FieldValue<T>(this DataRow row, string columnName, bool checkColumn = false)
    {
        return checkColumn && !row.Table.Columns.Contains(columnName)
            ? default(T)
            : row.Field<T>(columnName);
    }
