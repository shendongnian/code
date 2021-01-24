    foreach(var subclassType in subclassTypes)
    {
         MethodInfo method = GetType("GameObject").GetMethod("DoesEntityExist")
                                                  .MakeGenericMethod(new Type[] { subclassType });
         method.Invoke(GameObject, new object[] { });
    }
