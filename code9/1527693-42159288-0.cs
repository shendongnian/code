        internal sealed class Configuration : DbMigrationsConfiguration<SchoolDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
