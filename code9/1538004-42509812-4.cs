    public static class ConvExt {
        public static DataRow ConvFromDB<T>
            (this DataRow DR, out T field, string col_name)
        {
            return ConvFromDB(DR, out field, col_name, default(T));
        }
        public static DataRow ConvFromDB <T>
            (this DataRow DR, out T field, string col_name, T blank)
        {
            field = blank;
            if (DR[col_name] != DBNull.Value)
            {
                field = (T) DR[col_name];
            }
            return DR;
        }
    }
