    public static int Delete<T>(this IDbConnection connection, int Id)
    
    public static int Delete<T>(this IDbConnection connection, T entityToDelete)
    
    public static int DeleteList<T>(this IDbConnection connection, object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
    
    public static int DeleteList<T>(this IDbConnection connection, string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
