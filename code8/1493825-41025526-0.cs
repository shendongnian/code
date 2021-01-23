    public class SqlHashSet<T> : HashSet<T>, IEnumerable<SqlDataRecord>
    {
        private static readonly SqlDbType _sqlDbType = GetSqlDbType();
        private static SqlDbType GetSqlDbType()
        {
            if (typeof(T) == typeof(int))
                return SqlDbType.Int;
            if (typeof(T) == typeof(string))
                return SqlDbType.String;
        
            ...
        
            throw new InvalidOperationException($"Can't find the SqlDbType for {typeof(T)}");
        }
        
        ...
        
        SqlDataRecord ret = new SqlDataRecord(new SqlMetaData("value", _sqlDbType));
    }
