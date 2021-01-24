    public static class DynamicFuncHelper
    {
        public static Delegate CreateFunc(Type type1, Type type2)
        {
            Type funcType = typeof(Func<,,>).MakeGenericType(type1, type2, type1);
            MethodInfo method =
                typeof(DynamicFuncHelper<,>)
                .MakeGenericType(type1, type2)
                .GetMethod("SetAddressProperty",
                    BindingFlags.Public | BindingFlags.Static
                );
            return Delegate.CreateDelegate(funcType, method);
        }
    }
    public static class DynamicFuncHelper<T,U> 
        where T : class 
        where U : class
    {
        public static T SetAddressProperty(T obj1, U obj2)
        {
            obj1.GetType().InvokeMember("Address",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                Type.DefaultBinder, obj1, new[] { obj2 });
            return obj1;
        }
    }
