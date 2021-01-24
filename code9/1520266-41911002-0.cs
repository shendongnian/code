    public class MyCustomInitializer : IDatabaseInitializer<AppDbContext>
    {
        public void InitializeDatabase(AppDbContext context)
        {
            if (context.Database.Exists())
            {
                context.Database.Delete();
            }
            context.Database.Create();
            // populate data
        }
    }
