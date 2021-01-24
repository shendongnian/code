    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //On true you might be losing data be aware. 
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "Path To Your DbContext";
        }
    
        protected override void Seed(YourApplication.Infrastructure.Data.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.
    
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
