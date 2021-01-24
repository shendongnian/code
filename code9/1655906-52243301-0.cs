     protected override void OnModelCreating(ModelBuilder builder)
     {
         RegisterMaps(builder);
         base.OnModelCreating(builder);
     }
     private static void RegisterMaps(ModelBuilder builder)
     {
         var mapLists = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace)
                    && typeof(IEntityMap).IsAssignableFrom(type) 
                    && type.IsGenericType == false 
                    && type.IsClass).ToList();
         foreach (var item in mapLists)
         {
             Activator.CreateInstance(item, BindingFlags.Public | 
             BindingFlags.Instance, null, new object[] { builder }, null);
         }
    }
