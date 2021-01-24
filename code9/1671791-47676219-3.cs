    static void ConfigureSoftDelete<T>(ModelBuilder builder)
    	where T : class, IDeletableEntity
    {
    	builder.Entity<T>().Property<Boolean>("IsDeleted");
    	builder.Entity<T>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
    }
