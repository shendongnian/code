    public class MyContext : DbContext
    {
        static SpareParts2Context()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, MyContextConfiguration>(useSuppliedContext: true));
        }
    #if DEBUG
        public MyContext()
        {
            var stackTrace = new System.Diagnostics.StackTrace();
            var isMigration = stackTrace.GetFrames()?.Any(e => e.GetMethod().DeclaringType?.Namespace == typeof(System.Data.Entity.Migrations.Design.ToolingFacade).Namespace) ?? false;
            if (!isMigration)
                throw new InvalidOperationException($"The {GetType().Name} default constructor must be used exclusively for running Add-Migration in the Package Manager Console.");
        }
    #endif
        // ...
    }
