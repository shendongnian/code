    public static T GetValueOrDefault<T>(IDataRecord row, string fieldName, T defaultValue = default(T))
    {
        if (HasColumn(row, fieldName))
        {
            int ordinal = row.GetOrdinal(fieldName);
            object value = row.GetValue(ordinal);
            return row.IsDBNull(ordinal)
                ? defaultValue
                : ConvertValue<T>(value);
        }
        else
        {
            return defaultValue;
        }
    }
    public static bool HasColumn(IDataRecord row, string columnName)
    {
        for (var i = 0; i < row.FieldCount; i++)
        {
            if (row.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
    public static T ConvertValue<T>(object value)
    {
        var type = typeof(T);
        type = Nullable.GetUnderlyingType(type) ?? type;
        var result = Convert.ChangeType(value, type);
        return (T)result;
    }
