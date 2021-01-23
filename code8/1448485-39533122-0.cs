    private static void MakeCloneMethod(Type componentType, TypeBuilder typeBuilder)
    {
        Type thisType = typeBuilder.AsType();
        Type itype = typeof(IMyClonable);
        MethodInfo cloneMthd = itype.GetMethod("Clone");
        MethodBuilder cloneMthdBldr = typeBuilder.DefineMethod(
            cloneMthd.Name, cloneMthd.Attributes & ~MethodAttributes.Abstract, 
            itype, new Type[] {});
        typeBuilder.DefineMethodOverride(cloneMthdBldr, cloneMthd);
        ILGenerator gen = cloneMthdBldr.GetILGenerator();
        LocalBuilder returnValue = gen.DeclareLocal(thisType);
        gen.Emit(OpCodes.Newobj, typeBuilder.DefineDefaultConstructor(MethodAttributes.Public));
        gen.Emit(OpCodes.Stloc_S, returnValue);
        PropertyInfo[] allProperties = GetPublicProperties(componentType);
        foreach (PropertyInfo propInfo in allProperties)
        {
            gen.Emit(OpCodes.Ldloc_S, returnValue);
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldfld, builders[propInfo]);
            gen.Emit(OpCodes.Stfld, builders[propInfo]);
        }
        gen.Emit(OpCodes.Ldloc_S, returnValue);
        gen.Emit(OpCodes.Ret);
    }
