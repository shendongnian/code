    public class ObjectWrapperExt: ObjectInstance, IObjectWrapper
    {
        private ObjectWrapper _target;
        public ObjectWrapperExt(Engine engine, Object obj)
            : base(engine)
        {
            _target = new ObjectWrapper(engine, obj);
        }
        public object Target => _target.Target;
        public override PropertyDescriptor GetOwnProperty(string propertyName)
        {
            if (propertyName == "ToArray")
            {
                if (this.Properties.TryGetValue(propertyName, out var prop)) return prop;
                var descriptor = new PropertyDescriptor(new ToArrayFunctionInstance(Engine), false, true, false);
                Properties.Add(propertyName, descriptor);
                return descriptor;
            }
            return _target.GetOwnProperty(propertyName);
        }
        public override void Put(string propertyName, JsValue value, bool throwOnError)
        {
            _target.Put(propertyName, value, throwOnError);
        }
        public class ToArrayFunctionInstance : FunctionInstance
        {
            private static MethodInfo toArray = typeof(Enumerable).GetMethod("ToArray", BindingFlags.Static | BindingFlags.Public);
            public ToArrayFunctionInstance(Engine engine) : base(engine, null,null, false)
            {   
            }
            public override JsValue Call(JsValue thisObject, JsValue[] arguments)
            {
                var target = (thisObject.AsObject() is IObjectWrapper w)? w.Target : throw new NotSupportedException();
                var targetType = target.GetType();
                var enumImpl = targetType.GetInterfaces()
                    .Where(_ => _.IsGenericType)
                    .Where(_ => _.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    .FirstOrDefault();
                if(enumImpl != null)
                {
                    var arg = enumImpl.GetGenericArguments();
                    var value = toArray.MakeGenericMethod(arg).Invoke(null, new[] { target });
                    return JsValue.FromObject(Engine, value);
                }
                throw new NotSupportedException();
            }
        }
    }
