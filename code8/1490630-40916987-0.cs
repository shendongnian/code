    public static class MyFactory
    {
        public static T MyCreateInstance<T>()
            where T : class
        {
            // Checks if there is custom constructor
            var ctor = typeof(T)
                .GetConstructors()
                .FirstOrDefault(c => c.GetParameters().Length > 0);
            // If class has only default constructor return instance
            if (ctor == null)
            {
                return (T)Activator.CreateInstance(typeof (T));
            }
            // Get ctor parameters and use default value for optional parameter
            // if it is valuetype we should create instance of it 
            // For reference types default value should be null
            var result =
                ctor.Invoke
                    (ctor.GetParameters()
                        .Select(p =>
                            p.HasDefaultValue? p.DefaultValue :
                            p.ParameterType.IsValueType && Nullable.GetUnderlyingType(p.ParameterType) == null
                                ? Activator.CreateInstance(p.ParameterType)
                                : null
                        ).ToArray()
                    );
            return (T) result;
        }
    }
