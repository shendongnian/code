    // value type version that works with type inference
    public static void FieldValueStruct<T>(this DataRow row, string columnName, out T? value, bool checkColumn = false)
        where T : struct
    {
        value = row.GetValue(columnName, checkColumn, default(T), row.Field<T?>);
    }
    // reference type version that works with type inference
    public static void FieldValueClass<T>(this DataRow row, string columnName, out T value, bool checkColumn = false)
        where T : class
    {
        value = row.GetValue(columnName, checkColumn, default(T), row.Field<T>);
    }
