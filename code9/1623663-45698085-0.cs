    public static IEnumerable<T> Query<T>(
        this IDbConnection cnn, 
        string sql, 
        object param = null, 
        SqlTransaction transaction = null, 
        bool buffered = true
    )
