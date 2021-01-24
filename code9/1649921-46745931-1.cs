    public static Func<object, object> EmitUntypedGetter(PropertyInfo pi)
    {
        DynamicMethod method = new DynamicMethod(
            "PropertyGetter",
            typeof(Object),
            new[] { typeof(Object) },
            Assembly.GetExecutingAssembly().ManifestModule);
        ILGenerator il = method.GetILGenerator(100);
        // Load object onto the stack.
        il.Emit(OpCodes.Ldarg_0);
        // Call property getter
        il.EmitCall(OpCodes.Callvirt, pi.GetGetMethod(), null);
        // If property returns value-type, value must be boxed
        if(pi.PropertyType.IsValueType)
            il.Emit(OpCodes.Box, pi.PropertyType);
        // Exit method
        il.Emit(OpCodes.Ret);
        return (Func<Object, Object>)method.CreateDelegate(typeof(Func<Object, Object>));
    }
