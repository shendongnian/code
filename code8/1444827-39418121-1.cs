    var list = new List<Expression<Func<object>>> { () => notUsefulObject.usefulProp1, () => notUsefulObject.usefulProp2... };
    var nm = new AssemblyName("MyDynamicAssembly");
    TypeBuilder tb = Thread.GetDomain().DefineDynamicAssembly(nm, AssemblyBuilderAccess.RunAndSave).DefineDynamicModule(nm.Name, nm.Name + ".dll").DefineType("NewItem", TypeAttributes.Public);
    const MethodAttributes GetSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
    foreach (Expression b in list.Select(x => x.Body))
    {
        MemberInfo mi = ((MemberExpression)b).Member;
        Type t = b.Type;
        FieldBuilder fb = tb.DefineField(mi.Name.ToLower(), t, FieldAttributes.Private);
        PropertyBuilder pb = tb.DefineProperty(mi.Name, PropertyAttributes.HasDefault, t, null);
        MethodBuilder getBld = tb.DefineMethod("get_" + mi.Name, GetSetAttr, t, Type.EmptyTypes);
        ILGenerator getGen = getBld.GetILGenerator();
        getGen.Emit(OpCodes.Ldarg_0);
        getGen.Emit(OpCodes.Ldfld, fb);
        getGen.Emit(OpCodes.Ret);
        MethodBuilder setBld = tb.DefineMethod("set_" + mi.Name, GetSetAttr, null, new[] { t });
        ILGenerator setGen = setBld.GetILGenerator();
        setGen.Emit(OpCodes.Ldarg_0);
        setGen.Emit(OpCodes.Ldarg_1);
        setGen.Emit(OpCodes.Stfld, fb);
        setGen.Emit(OpCodes.Ret);
        pb.SetGetMethod(getBld);
        pb.SetSetMethod(setBld);
    }
    object usefulObject = Activator.CreateInstance(tb.CreateType());
