    var indexes = Assembly.GetAssembly(indexBase)
         .GetTypes()
         .Where(type =>
             type != indexBase &&
             !type.IsInterface &&
             !type.IsAbstract &&
             type.BaseType.IsAssignableFrom(indexBase))
         .ToList();
