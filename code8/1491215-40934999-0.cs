    var typesThatHasSomeTypeAsProperty = 
        assemblies.SelectMany(assembly => 
          assembly.GetTypes().Where(type => 
            type.GetProperties.Any(property => 
              property.PropertyType == someType)))
       .Distinct().ToList();
