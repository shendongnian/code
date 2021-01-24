    var toCallInfo = typeof(InternalCall).GetMethod("InternalMethod", BindingFlags.Static | BindingFlags.NonPublic);
    unsafe
    {
        var functionPointer = toCallInfo.MethodHandle.GetFunctionPointer();
        if (sizeof(IntPtr) == 4)
            il.Emit(OpCodes.Ldc_I4, (int)functionPointer);
        else
            il.Emit(OpCodes.Ldc_I8, (long)functionPointer);
    }
    il.EmitCalli(OpCodes.Calli, toCallInfo.CallingConvention, null, null, null);
    il.Emit(OpCodes.Ret);
