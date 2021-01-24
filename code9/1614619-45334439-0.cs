    var il = mbuilder.GetILGenerator();
    var genericType = typeof(GenericType<>).MakeGenericType(typeof(TOutput));
    il.Emit(OpCodes.Newobj, genericType.GetConstructor(Type.EmptyTypes));
    il.EmitCall(OpCodes.Callvirt, genericType.GetMethod("MethodName", Type.EmptyTypes), null);
    il.Emit(OpCodes.Ret);
