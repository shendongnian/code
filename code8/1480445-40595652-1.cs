    modelBuilder.Types()
    	.Where(type => !type.GetCustomAttributes(false).OfType<TableAttribute>().Any() && type.GetCustomAttributes(false).OfType<ModulePrefixAttribute>().Any())
    	.Configure(config => config.ToTable(GetTableName(config.ClrType)));
    
    modelBuilder.Properties()
    	.Where(property => property.Name != "Id" && property.DeclaringType.GetCustomAttributes(false).OfType<TablePrefixAttribute>().Any() && property.DeclaringType == property.ReflectedType)
    	.Configure(config => config.HasColumnName(GetColumnName(config.ClrPropertyInfo.DeclaringType, config.ClrPropertyInfo.Name)));
    
    modelBuilder.Properties()
    	.Where(property => property.Name == "Id" && property.DeclaringType.GetCustomAttributes(false).OfType<TablePrefixAttribute>().Any())
    	.Configure(config => config.IsKey().HasColumnName(GetColumnName(config.ClrPropertyInfo.ReflectedType, "Id")));
