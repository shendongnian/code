    public static Func<T, int, T> CreatePointerFieldSetMethod<T>(FieldInfo field)
    {
		var dynamicMethod = new DynamicMethod("SetFieldFromPointer", typeof(T), new[] { typeof(T), typeof(int) }, true);
		ILGenerator generator = dynamicMethod.GetILGenerator();
		
		var unboxFunc = typeof(CustomBox<>).MakeGenericType(field.FieldType).GetMethod("Unbox", BindingFlags.Static | BindingFlags.Public);
		
		var loc0_val = generator.DeclareLocal(field.FieldType);
        var loc1_target = generator.DeclareLocal(field.DeclaringType);
        var label = generator.DefineLabel();
        // IL_0000: nop
		generator.Emit(OpCodes.Nop);
        // IL_0001: ldarg.1
		generator.Emit(OpCodes.Ldarg_1);
        // IL_0002: call !0 valuetype CPURaceTest.CustomBox`1<uint8>::Unbox(int32)
		generator.EmitCall(OpCodes.Call, unboxFunc, null);
        // IL_0007: stloc.0
		generator.Emit(OpCodes.Stloc, loc0_val);
        if(field.DeclaringType.IsValueType)
        {
            // IL_0008: ldarga.s target
            generator.Emit(OpCodes.Ldarga_S, 0);
        }
        else
        {
            // IL_0008: ldarg.0
            generator.Emit(OpCodes.Ldarg_0);
        }
        // IL_000a: ldloc.0
		generator.Emit(OpCodes.Ldloc, loc0_val);
        // IL_000b: stfld uint8 CPURaceTest.MyStruct::Number
		generator.Emit(OpCodes.Stfld, field);
        // IL_0010: ldarg.0
        generator.Emit(OpCodes.Ldarg_0);
        // IL_0011: stloc.1
        generator.Emit(OpCodes.Stloc, loc1_target);
        // IL_0012: br.s IL_0014
        generator.Emit(OpCodes.Br_S, label);
            
        // IL_0014: ldloc.1
        generator.MarkLabel(label);
		generator.Emit(OpCodes.Ldloc, loc1_target);
        // IL_0015: ret
		generator.Emit(OpCodes.Ret);
		return (Func<T, int, T>)dynamicMethod.CreateDelegate(typeof(Func<T, int, T>));
    }
