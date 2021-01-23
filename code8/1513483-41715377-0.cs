    public void FindParentClass<T> where T: ISomeInterface, new()
    {
       var parentClass = typeof(T).GetTypeInfo().ReflectedType;
       var grandparentClass = parentClass.GetTypeInfo().ReflectedType;
       var method = MethodBase.GetCurrentMethod().DeclaringType.GetMethod("PerformWith", BindingFlags.NonPublic());
       var genericMethod = method.MakeGenericMethod(new Type[] { grandparentClass, parentClass, typeof(T) });
       genericMethod.Invoke(null, null);
    }
       
