    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       ...
       var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                 type.BaseType != null &&
                 type.BaseType.IsGenericType &&
                 type.BaseType.GetGenericTypeDefinition() == typeof (EntityTypeConfiguration<>));
    
       foreach (var type in typesToRegister)
       {
          dynamic configurationInstance = Activator.CreateInstance(type);
          modelBuilder.Configurations.Add(configurationInstance);
       }
    
       base.OnModelCreating(modelBuilder);
    }
