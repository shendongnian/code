     static void Main(string[] args)
     {
         var hs1 = new HashSet<SomePrivateClass>();
         CallClear(hs1);
     }
     public static void CallClear(object objectThatIsAHashSet)
     {
         var method = typeof(Program).GetMethod("Clear", BindingFlags.Public | BindingFlags.Static);
         var hsGenericType = objectThatIsAHashSet.GetType().GetGenericArguments()[0];
         var genericMethod = method.MakeGenericMethod(hsGenericType);
         genericMethod.Invoke(null, new[] {objectThatIsAHashSet});
     }
    private class SomePrivateClass { }
    public static void Clear<T>(HashSet<T> hs)
    {
        hs.Clear();
    }
