    public class Class1<T1>
    {
        public static object GetObj()
        {
            if (typeof(SomeBaseClass).IsAssignableFrom(typeof(T1)))
            {
                var genericType = typeof(Class2<>).MakeGenericType(typeof(T1));
                return Activator.CreateInstance(genericType);
            }
 
            // throw Exception or return null
        }
    }
