    namespace Default.Migrations
    {
    using System.Data.Entity.Migrations;
    public sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(Context context)
        {
           ///
        }
    }
    }
