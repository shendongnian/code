    var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
    var configurationMethod = typeof(BaseEntityConfiguration).GetMethod("ConfigureBaseEntity");
    foreach (Type t in typeof(BaseEntity).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(BaseEntity))))
    {
        var configurator = entityMethod.MakeGenericMethod(t).Invoke(modelBuilder, new object[0]);
        configurationMethod.MakeGenericMethod(t).Invoke(null, new object[1] { configurator });
    }
