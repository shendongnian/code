    protected void Execute(Action<IDbConnection> query)
    {
        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString))
        {
            query.Invoke(db);
        }
    }
