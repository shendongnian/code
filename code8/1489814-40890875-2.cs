    static void CallGenerateVar()
    {
        var dm = new DynamicMethod("CallGenerateVar", typeof(object), Type.EmptyTypes, typeof(TestClass));
        MethodInfo generateVarMethod = typeof(TestClass).GetMethod("GenerateVar", BindingFlags.Public | BindingFlags.Instance);
        var ilGen = dm.GetILGenerator();
        var properties = ilGen.DeclareLocal(typeof(PropertyInfo[]));
        var index = ilGen.DeclareLocal(typeof(int));
        var propInfo = ilGen.DeclareLocal(typeof(PropertyInfo));
        ilGen.Emit(System.Reflection.Emit.OpCodes.Ldtoken, typeof(Foo));
        ilGen.Emit(System.Reflection.Emit.OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle", BindingFlags.Static | BindingFlags.Public));
        ilGen.Emit(System.Reflection.Emit.OpCodes.Callvirt, typeof(Type).GetMethod("GetProperties", Type.EmptyTypes));
        ilGen.Emit(System.Reflection.Emit.OpCodes.Stloc_0);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Ldc_I4_0);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Stloc_1);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Ldloc_0);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Ldloc_1);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Ldelem_Ref);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Stloc_2);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Ldloc_0);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Ldloc_2);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Callvirt, typeof(PropertyInfo).GetMethod("get_PropertyType", BindingFlags.Instance | BindingFlags.Public));
        ilGen.Emit(System.Reflection.Emit.OpCodes.Callvirt, generateVarMethod);
        ilGen.Emit(System.Reflection.Emit.OpCodes.Ret);
        var del = (Func<object>)dm.CreateDelegate(typeof(Func<object>));
        var result = del.Invoke();
    }
