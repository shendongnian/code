    public class Wrapper
    {
        public static void Invoke<TApi>(Action<TApi> method)
        {
            var instance = Activator.CreateInstance<TApi>();
            method.Invoke(instance);
        }
        public static TReturn Invoke<TApi, TReturn> (Expression<Func<TApi, TReturn>> method)
        {
            var instance = Activator.CreateInstance<TApi>();
            Func<TApi, TReturn> compiled = method.Compile();
            return compiled(instance);
        }
    }
 
