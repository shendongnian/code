    internal sealed class Configuration : DbMigrationConfiguration<TodoDbContext>
    {
        public Configuration()
        {
            // ...
        }
        protected override void Seed(TodoDbContext context)
        {
            // ...
        }
    }
