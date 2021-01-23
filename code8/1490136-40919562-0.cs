	public static Action<object, int> CreatePointerFieldSetMethod(FieldInfo field)
	{
		var setMethod = new DynamicMethod("SetFieldFromPointer", typeof(void), new[] { typeof(object), typeof(int) }, true);
		ILGenerator generator = setMethod.GetILGenerator();
		
		var unboxFunc = typeof(CustomBox<>).MakeGenericType(field.FieldType).GetMethod("Unbox", BindingFlags.Static | BindingFlags.Public);
		
		var local = generator.DeclareLocal(field.FieldType); // Delcare a local.
		
		generator.Emit(OpCodes.Ldarg_1);
		generator.EmitCall(OpCodes.Call, unboxFunc, null);
		generator.Emit(OpCodes.Stloc, local); // Use the declared local.
		
		generator.Emit(OpCodes.Ldarg_0);
		generator.Emit(OpCodes.Castclass, field.DeclaringType); // Added this cast.
		generator.Emit(OpCodes.Ldloc, local); // Use the declared local.
		generator.Emit(OpCodes.Stfld, field);
		
		generator.Emit(OpCodes.Ret);
		return (Action<object, int>)setMethod.CreateDelegate(typeof(Action<object, int>));
	}
