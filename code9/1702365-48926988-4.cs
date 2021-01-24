    foreach(var subclassType in subclassTypes)
    {
         MethodInfo method = GetType("GameObject").GetMethod("FindObjectsOfType")
                                                  .MakeGenericMethod(new Type[] { subclassType });
         method.Invoke(gameObject, new object[] { });
    }
