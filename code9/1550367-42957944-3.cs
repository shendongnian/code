    public T Get<T>(Func<IDbConnection, T> query)
    {
        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString))
        {
            return query.Invoke(db); 
        }
    }
