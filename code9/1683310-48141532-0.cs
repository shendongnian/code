    TypeDefinition someClass;
    MethodDefinition someMethod;
    {
        someClass = new TypeDefinition("ConsoleDemo", "SomeClass", TypeAttributes.Class | TypeAttributes.Public, module.TypeSystem.Object);
        someMethod = new MethodDefinition("SomeMethod", MethodAttributes.Public, module.TypeSystem.Int32);
        someMethod.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4_0));
        someMethod.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
        someClass.Methods.Add(someMethod);
        var someClassCtor = new MethodDefinition(".ctor", MethodAttributes.SpecialName | MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.RTSpecialName, module.TypeSystem.Void);
        someClassCtor.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
        someClassCtor.Body.Instructions.Add(Instruction.Create(OpCodes.Call, objCtor));
        someClassCtor.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
        someClass.Methods.Add(someClassCtor);
        module.Types.Add(someClass);
    }
