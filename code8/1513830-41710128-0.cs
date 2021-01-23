	if (fieldInfo.IsStatic)
	{
		setterIL.Emit(OpCodes.Ldarg_0);
		setterIL.Emit(OpCodes.Stsfld, fieldInfo);
		setterIL.Emit(OpCodes.Ret);
	}
	else
	{
		setterIL.Emit(OpCodes.Ldarg_0);
		setterIL.Emit(OpCodes.Ldarg_1);
		setterIL.Emit(OpCodes.Stfld, fieldInfo);
		setterIL.Emit(OpCodes.Ret);
	}
