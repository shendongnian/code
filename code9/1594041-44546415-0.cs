    public static class IDataReaderExtensions
    {
        public static T GetValueOrDefault<T>(this IDataReader reader, int index)
        {
            return (Convert.IsDBNull(reader[index])) ? default(T) : (T)reader.GetValue(index);
        }
        public static T GetValueOrDefault<T>(this IDataReader reader, string name)
        {
            return reader.GetValueOrDefault<T>(reader.GetOrdinal(name));
        }
    }
