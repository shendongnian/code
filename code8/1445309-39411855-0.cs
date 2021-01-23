    public class Test2
    {
        private static readonly Action<MemoryStream, object> del;
    
        static Test2()
        {
            var genericCreateMethod = typeof(Test2).GetMethod("CreateWriteDelegate", BindingFlags.Static | BindingFlags.NonPublic);
            var specificCreateMethod = genericCreateMethod.MakeGenericMethod(typeof(Model));
            del = (Action<MemoryStream, object>)specificCreateMethod.Invoke(null, null);
        }
    
        public static void Write(MemoryStream s, object value)
        {
            del(s, value);
        }
    
        private static Action<MemoryStream, object> CreateWriteDelegate<T>()
        {
            var handler = HandlerFactory.Create<T>();
            return delegate (MemoryStream s, object value)
            {
                handler.Write(s, (T)value);
            };
        }
    }
