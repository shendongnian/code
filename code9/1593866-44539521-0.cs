    public static class DataRowExtensionMethods
    {
        public static int ReturnIntForField(this DataRow data, string fieldName)
        {
            return data[fieldName] == DBNull.Value ? 0 : Convert.ToInt32(data[fieldName]);
        }
    
        public static DateTime ReturnDateTimeFromDataRowField(this DataRow data, string fieldName)
        {
            return Convert.ToDateTime(data[fieldName]);
        }
    } \\etc... etc...
