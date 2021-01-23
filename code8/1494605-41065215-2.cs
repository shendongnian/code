    AppDomain myDomain = AppDomain.CurrentDomain;
    AssemblyName myAsmName = new AssemblyName("GenericEmit");
    AssemblyBuilder myAssembly = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave);
    ModuleBuilder myModule = myAssembly.DefineDynamicModule(myAsmName.Name, myAsmName.Name + ".dll");
    TypeBuilder myType = myModule.DefineType("Sample", TypeAttributes.Public);
    Type listOf = typeof(List<>);
    Type selfContained = listOf.MakeGenericType(myType);
    //define a backingfield
    FieldBuilder field = myType.DefineField("<Items>_BackingField", selfContained, FieldAttributes.Private);
    //define a parameterless constructor to initialize the field.
    ConstructorBuilder constructor = myType.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, Type.EmptyTypes);
    ILGenerator constructorBody = constructor.GetILGenerator();
    constructorBody.Emit(OpCodes.Ldarg_0);
    constructorBody.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
    constructorBody.Emit(OpCodes.Ldarg_0);
    constructorBody.Emit(OpCodes.Newobj, TypeBuilder.GetConstructor(selfContained, listOf.GetConstructor(Type.EmptyTypes)));
    constructorBody.Emit(OpCodes.Stfld, field);
    constructorBody.Emit(OpCodes.Ret);
    //define the getter
    MethodBuilder getter = myType.DefineMethod("get_Items", MethodAttributes.Public | MethodAttributes.HideBySig, selfContained, Type.EmptyTypes);
    ILGenerator getterBody = getter.GetILGenerator();
    getterBody.Emit(OpCodes.Ldarg_0);
    getterBody.Emit(OpCodes.Ldfld, field);
    getterBody.Emit(OpCodes.Ret);
    //define the setter
    MethodBuilder setter = myType.DefineMethod("set_Items", MethodAttributes.Public | MethodAttributes.HideBySig, typeof(void), new Type[] { selfContained });
    ILGenerator setterBody = setter.GetILGenerator();
    setterBody.Emit(OpCodes.Ldarg_0);
    setterBody.Emit(OpCodes.Ldarg_1);
    setterBody.Emit(OpCodes.Stfld, field);
    setterBody.Emit(OpCodes.Ret);
    PropertyBuilder property = myType.DefineProperty("Items", PropertyAttributes.None, selfContained, null);
    //Bind getter and setter
    property.SetGetMethod(getter);
    property.SetSetMethod(setter);
    Type type = myType.CreateType();
    myAssembly.Save(myAsmName.Name + ".dll");
    var sample = Activator.CreateInstance(type);
