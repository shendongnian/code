    var retType = typeof(TOutput);
    var type = typeof(GenericType<>);
    var genericType = type.MakeGenericType(retType);
    var constructor = genericType.GetConstructor(Type.EmptyTypes);
    var methodDef = genericType.GetMethod("MethodName", Type.EmptyTypes);
    var newMethod = new DynamicMethod("MyMethod", retType, Type.EmptyTypes);
    var generator = newMethod.GetILGenerator();
    generator.DeclareLocal(genericType);
    generator.DeclareLocal(retType);
    generator.Emit(OpCodes.Newobj, constructor);
    generator.Emit(OpCodes.Stloc_0);
    generator.Emit(OpCodes.Ldloc_0);
    generator.EmitCall(OpCodes.Callvirt, methodDef, null);
    generator.Emit(OpCodes.Stloc_1);
    generator.Emit(OpCodes.Ldloc_1);
    generator.Emit(OpCodes.Ret);
    var ret = newMethod.Invoke(null, null);
    Console.WriteLine(ret); // App.TOutput
