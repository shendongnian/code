      Type[] formatStringArgs = { typeof(string), typeof(int), typeof(string), typeof(int) };
       MethodInfo formatString = typeof(String).GetMethod("Format", formatStringArgs);
       il = toStringMethod.GetILGenerator();
       il.Emit(OpCodes.Nop);
       il.Emit(OpCodes.Ldstr, "{0},{1},{2}");
       il.Emit(OpCodes.Ldarg_0);
       il.Emit(OpCodes.Call, getIdMethodeBuilder);
       il.Emit(OpCodes.Box, typeof(Int32));
       il.Emit(OpCodes.Ldarg_0);                   
       il.Emit(OpCodes.Call, getDescriptionMethodeBuilder);
       il.Emit(OpCodes.Ldarg_0);
       il.Emit(OpCodes.Call, getParentIdMethodeBuilder);
       il.Emit(OpCodes.Box, typeof(Int32));
       il.Emit(OpCodes.Call, formatString);
       il.Emit(OpCodes.Ret);
       typebuilder.DefineMethodOverride(toStringMethod, 
       typeof(object).GetMethod("ToString"));
