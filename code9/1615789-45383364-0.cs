     Type propertyType = ...;
     var ilGenerator = method.GetILGenerator();
     ilGenerator.Emit(OpCodes.Ldarg_0);
     ilGenerator.Emit(OpCodes.Ldarg_1);
     if (propertyType.IsValueType)
         ilGenerator.Emit(OpCodes.Unbox, propertyType);
     ilGenerator.Emit(OpCodes.Call, setMethod);
     ilGenerator.Emit(OpCodes.Ret);
