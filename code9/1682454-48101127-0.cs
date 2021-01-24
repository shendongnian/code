     public static Func<A1, T> BuildLambda<A1, T>(string propertyName)
     {
       // This is where the magic happens with the last parameter!!
       DynamicMethod dm = new DynamicMethod("Create", typeof(T), new Type[] { typeof(A1) }, typeof(Program).Module);
    
       // Everything else is just generating IL-code at runtime to create the class and set the property
       var setter = typeof(T).GetProperty(propertyName).SetMethod;
       var generator = dm.GetILGenerator();
       var local = generator.DeclareLocal(typeof(T));
       generator.Emit(OpCodes.Newobj, typeof(Class1).GetConstructor(Type.EmptyTypes));
       generator.Emit(OpCodes.Stloc, local);
       generator.Emit(OpCodes.Ldloc, local);
       generator.Emit(OpCodes.Ldarg_0);
       generator.Emit(OpCodes.Call, setter);
       generator.Emit(OpCodes.Ldloc, local);
       generator.Emit(OpCodes.Ret);
       return (Func<A1, T>)dm.CreateDelegate(typeof(Func<A1, T>));
    }
