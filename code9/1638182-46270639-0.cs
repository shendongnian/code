        TypeBuilder typeBuilder = moduleBuilder.DefineType(name, TypeAttributes.Public);
        typeBuilder.AddInterfaceImplementation(typeof(INativeValueAccessor<T>));
        // ReadData method
        MethodBuilder methodBuilder1 = typeBuilder.DefineMethod("ReadData", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig);
        methodBuilder1.SetReturnType(itemType);
        methodBuilder1.SetParameters(typeof(byte*));
        ILGenerator codeGen1 = methodBuilder1.GetILGenerator();
        codeGen1.Emit(OpCodes.Ldarg_1);
        codeGen1.Emit(OpCodes.Ldobj, itemType);
        codeGen1.Emit(OpCodes.Ret);
        // WriteData method
        MethodBuilder methodBuilder2 = typeBuilder.DefineMethod("WriteData", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig);
        methodBuilder2.SetReturnType(null);
        methodBuilder2.SetParameters(itemType, typeof(byte*));
        ILGenerator codeGen2 = methodBuilder2.GetILGenerator();
        codeGen2.Emit(OpCodes.Ldarg_2);
        codeGen2.Emit(OpCodes.Ldarg_1);
        codeGen2.Emit(OpCodes.Stobj, itemType);
        codeGen2.Emit(OpCodes.Ret);
        Type generatedType = typeBuilder.CreateType();
        return Activator.CreateInstance(generatedType);
