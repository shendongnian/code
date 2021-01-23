    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(MyContext context)
        {
            context.Users.AddOrUpdate(
                p => p.Name,
                new User {Name = "Test User #1"},
                new User {Name = "Test User #2"},
                new User {Name = "Test User #3"});
        }
    }
