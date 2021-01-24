    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.ApplyConfiguration(new ExampleEntityConfiguration());
        // get ApplyConfiguration method with reflection
        var applyGenericMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);            
        // replace GetExecutingAssembly with assembly where your configurations are if necessary
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes()) {
            // use type.Namespace to filter by namespace if necessary
            foreach (var iface in type.GetInterfaces()) {
                // if type implements interface IEntityTypeConfiguration<SomeEntity>
                if (iface.IsConstructedGenericType && iface.Name == "IEntityTypeConfiguration`1") {
                    // make concrete ApplyConfiguration<SomeEntity> method
                    var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                    // and invoke that with fresh instance of your configuration type
                    applyConcreteMethod.Invoke(modelBuilder, new object[] {Activator.CreateInstance(type)});
                }
            }
        }
    }
