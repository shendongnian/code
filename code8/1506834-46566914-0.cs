    public static class TypeBuilderExtensions
    {
        public static PropertyBuilder CreateProperty<T>(this TypeBuilder builder, string name) => CreateProperty(builder, typeof(T), name);
    
        public static PropertyBuilder CreateProperty(this TypeBuilder builder, Type propertyType,  string name)
        {
            var field = builder.DefineField($"_{name}", propertyType, FieldAttributes.Private);
            var getMethodBuilder = builder.DefineMethod($"get_{name}", MethodAttributes.Public, propertyType, Type.EmptyTypes);
            var getGenerator = getMethodBuilder.GetILGenerator();
            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Ldfld, field);
            getGenerator.Emit(OpCodes.Ret);
    
            var setMethodBuilder = builder.DefineMethod($"set_{name}", MethodAttributes.Public, typeof(void), new[] { propertyType });
            var setGenerator = setMethodBuilder.GetILGenerator();
            setGenerator.Emit(OpCodes.Ldarg_0);
            setGenerator.Emit(OpCodes.Ldarg_1);
            setGenerator.Emit(OpCodes.Stfld, field);
            setGenerator.Emit(OpCodes.Ret);
    
            var propertyBuilder = builder.DefineProperty(name, PropertyAttributes.None, propertyType, Type.EmptyTypes);
            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);
            return propertyBuilder;
        }
    
        public static PropertyBuilder CreateCalculatedProperty<T>(this TypeBuilder builder, string name, MethodInfo getObject, MethodInfo getObjectProperty) => CreateCalculatedProperty(builder, typeof(T), name, getObject, getObjectProperty);
        
        public static PropertyBuilder CreateCalculatedProperty(this TypeBuilder builder, Type propertyType, string name, MethodInfo getObject, MethodInfo getObjectProperty)
        {
            var getMethodBuilder = builder.DefineMethod($"get_{name}", MethodAttributes.Public, propertyType, Type.EmptyTypes);
            var getGenerator = getMethodBuilder.GetILGenerator();
            var label = getGenerator.DefineLabel();
            var local = getGenerator.DeclareLocal(propertyType);
            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Callvirt, getObject);
            getGenerator.Emit(OpCodes.Brtrue, label);
            getGenerator.Emit(OpCodes.Ldloca_S, local);
            getGenerator.Emit(OpCodes.Initobj, propertyType);
            getGenerator.Emit(OpCodes.Ldloc, local);
            getGenerator.Emit(OpCodes.Ret);
            getGenerator.MarkLabel(label);
            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Callvirt, getObject);
            getGenerator.Emit(OpCodes.Callvirt, getObjectProperty);
            getGenerator.Emit(OpCodes.Ret);
    
            var propertyBuilder = builder.DefineProperty(name, PropertyAttributes.None, propertyType, Type.EmptyTypes);
            propertyBuilder.SetGetMethod(getMethodBuilder);
            return propertyBuilder;
        }
    }
    
