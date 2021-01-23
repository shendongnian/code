    if (val.GetType().IsGenericType && 
        val.GetType().GetGenericTypeDefinition() == 
        typeof(List<string>).GetGenericTypeDefinition()) { // string - whatever
      ...
    }
