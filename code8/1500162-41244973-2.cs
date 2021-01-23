    var method = assembly.GetTypes()[0].GetMethod("Write");
    var dynamicMethod = new DynamicMethod("Write", typeof(void), new Type[] { typeof(string) });
    var ilGenerator = dynamicMethod.GetILGenerator();
    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ldstr, "this is test");
    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Call, method);
    ilGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
    var delegateVoid = dynamicMethod.CreateDelegate(typeof(Write)) as Write;
    delegateVoid("test");
