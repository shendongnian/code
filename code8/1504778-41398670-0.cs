    il = getDepthMethod.GetILGenerator();
            
    var notNullLabel = il.DefineLabel();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Call, getParentMethod);
    il.Emit(OpCodes.Brtrue_S, notNullLabel);
    il.Emit(OpCodes.Ldc_I4_M1);
    il.Emit(OpCodes.Ret);
    il.MarkLabel(notNullLabel);
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Call, getParentMethod);
    il.Emit(OpCodes.Callvirt, getDepthMethod);
    il.Emit(OpCodes.Ldc_I4_1);
    il.Emit(OpCodes.Add);
    il.Emit(OpCodes.Ret);
