    public static class Extensions
    {
        public static T Get<T>(this T input) where T:class
        {
            Type t = input.GetType();
            MethodInfo method = t.GetMethod("Get");
            MethodInfo generic = method.MakeGenericMethod(t);
            return (T)generic.Invoke(input,null);
        }
    }
