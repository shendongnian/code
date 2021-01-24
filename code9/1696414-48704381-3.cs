	var builder = new ModelBuilder();
	// Get method
    MethodInfo entityMethodModelBuilder = typeof(ModelBuilder)
                                                   .GetMethod(nameof(ModelBuilder.Entity));
	foreach (var type in types) {
		// Get the Generic Type of the EntityTypeConfiguration
		var entType = type.BaseType.GetGenericArguments().First();
		// Ensure the Entity method is Generic.
		MethodInfo genericEmmb = entityMethodModelBuilder.MakeGenericMethod(entType);
		// Get EntityTypeBuilder<entType>
		var value = genericEmmb.Invoke(builder, null);
		// Get new type
		var config = Activator.CreateInstance(type);
		// Get method
		MethodInfo mapMethod = type.GetMethod("Map");
        // Call :Map() on the config object
		mapMethod.Invoke(config, new object[] { value });
	}
