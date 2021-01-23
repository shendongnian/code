    public static class MyFactory
    {
        public static T MyCreateInstance<T>()
            where T : class
        {
            return (T) MyCreateInstance(typeof (T));
        }
        public static object MyCreateInstance(Type type)
        {
            var ctor = type
                .GetConstructors()
                .FirstOrDefault(c => c.GetParameters().Length > 0);
            if (ctor == null)
            {
                return Activator.CreateInstance(type);
            }
            return
                ctor.Invoke
                    (ctor.GetParameters()
                        .Select(p =>
                            p.HasDefaultValue? p.DefaultValue :
                            p.ParameterType.IsValueType && Nullable.GetUnderlyingType(p.ParameterType) == null
                                ? Activator.CreateInstance(p.ParameterType)
                                : null
                        ).ToArray()
                    );
        }
    }
