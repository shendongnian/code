    return AppDomain.CurrentDomain.GetAssemblies()
      .Select(s => s.GetTypes())
      .Where(t => typeof(IClass).IsAssignableFrom(t))
      .SelectMany(t => 
         t.GetCustomAttributes(typeof(KeyAttribute), true))
           .Select(a => new 
            { 
               constInfo = t.GetConstructors(BindingFlags.Public).First(), 
               attrVal = a.Value 
            }))
      .ToDictionary(entry => entry.attrVal, entry => entry.constInfo);
   
