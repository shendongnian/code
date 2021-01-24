    Person person = new Person( "Antiduh", "United States" );
    
    var genericType = typeof(GenericType<>).MakeGenericType(typeof(TOutput));
    il.Emit(OpCodes.Newobj, genericType.GetConstructor(Type.EmptyTypes));
    
    // This doesn't make sense. The object referred to by 
    // my `person` variable doesn't exist in the generated program.
    il.Emit(OpCodes.Ldobj, person);
    il.Emit(OpCodes.Callvirt, genericeClientHelper.GetMethod("MethodName", new Type[] { typeof(MethodInfo) }));
    il.Emit(OpCodes.Ret);
