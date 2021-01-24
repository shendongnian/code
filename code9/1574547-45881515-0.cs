    class MyDBContext: DbContext
    {
        static MyDBContext()
        {
            DbInterception.Add(new SqliteInterceptor());
        }
    }
