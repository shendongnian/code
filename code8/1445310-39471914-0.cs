    public class Test
    {
        static Dictionary<Type, IHandler> delegates = new Dictionary<Type, IHandler>();
        public static void Write(MemoryStream s, object value)
        {
            IHandler handler;
            var type = value.GetType();
            if (!delegates.TryGetValue(type, out handler))
            {
                handler = (IHandler)typeof(HandlerFactory).GetMethod(nameof(HandlerFactory.Create)).MakeGenericMethod(type).Invoke(null, null);
                delegates[type] = handler;
            }
            handler.Write(s, value);
        }
    }
