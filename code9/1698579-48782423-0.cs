    MethodBuilder incPropMthdBldr =
				tb.DefineMethod("_Inc" + propertyName,
				  MethodAttributes.Public ,
				  null, new[] { propertyType });
			incPropMthdBldr.DefineParameter(0, ParameterAttributes.In, "increaseBy");
			ILGenerator incIl = incPropMthdBldr.GetILGenerator();
			
			incIl.Emit(OpCodes.Nop);
			incIl.Emit(OpCodes.Ldarg_0);
			incIl.Emit(OpCodes.Ldarg_0);
			incIl.Emit(OpCodes.Ldfld, fieldBuilder);
			incIl.Emit(OpCodes.Ldarg_1);
			incIl.Emit(OpCodes.Add);
			incIl.Emit(OpCodes.Stfld, fieldBuilder);			
			incIl.Emit(OpCodes.Ret);
