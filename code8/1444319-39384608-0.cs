    public class JsonSerializationBinder : SerializationBinder
    {
        readonly SerializationBinder binder;
        public JsonSerializationBinder(SerializationBinder binder)
        {
            if (binder == null)
                throw new ArgumentNullException();
            this.binder = binder;
        }
        public override Type BindToType(string assemblyName, string typeName)
        {
            try
            {
                return binder.BindToType(assemblyName, typeName);
            }
            catch (Exception ex)
            {
                throw new JsonSerializationBinderException(ex.Message, ex);
            }
        }
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            binder.BindToName(serializedType, out assemblyName, out typeName);
        }
    }
    public class JsonSerializationBinderException : JsonSerializationException
    {
        public JsonSerializationBinderException()
        {
        }
        public JsonSerializationBinderException(string message)
            : base(message)
        {
        }
        public JsonSerializationBinderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public JsonSerializationBinderException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
