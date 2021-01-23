    public class YourDbContext : DbContext
    {
        static YourDbContext()
        {
            Sp.CallInterceptor.Install();
        }
        // ...
    }
