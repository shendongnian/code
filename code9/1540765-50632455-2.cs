     public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register Entity Framework
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<SalesDbContext>().UseSqlServer("MyConnectionString");
            builder.RegisterType<SalesDbContext>()
                .WithParameter("options", dbContextOptionsBuilder.Options)
                .InstancePerLifetimeScope(); 
        }
    }
