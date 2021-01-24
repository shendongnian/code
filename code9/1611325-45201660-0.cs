    // value type version
    public static T? FieldValueStruct<T>(this DataRow row, string columnName, bool checkColumn = false)
        where T : struct
    {
        return row.GetValue(columnName, checkColumn, default(T), row.Field<T? /*with a question mark!!!*/ >);
    }
    // reference type version
    public static T FieldValueClass<T>(this DataRow row, string columnName, bool checkColumn = false)
        where T : class
    {
        return row.GetValue(columnName, checkColumn, default(T), row.Field<T>);
    }
    // shared amongst value and reference type implementation
    private static T GetValue<T>(this DataRow row, string columnName, bool checkColumn, T defaultValue, Func<string, T> getter)
    {
        return checkColumn && !row.Table.Columns.Contains(columnName)
            ? defaultValue
            : getter(columnName);
    }
