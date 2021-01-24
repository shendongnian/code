    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseMigApp.PatientContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(DatabaseMigApp.PatientContext context)
        {
        }
    }
