    internal sealed class Configuration : DbMigrationsConfiguration<eDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //know this might loss data while its true. 
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Path to your DbContext Class";
        }
        protected override void Seed(eDbContext context)
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
