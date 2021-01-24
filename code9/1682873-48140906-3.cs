    var initFields = new MethodDefinition($"{namePrefix}InitFields", MethodAttributes.Private, module.TypeSystem.Void);
    foreach (var field in newFields)
    {
        initFields.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
        initFields.Body.Instructions.Add(Instruction.Create(OpCodes.Newobj, field.Key.Resolve().GetConstructors().First()));
        initFields.Body.Instructions.Add(Instruction.Create(OpCodes.Stfld, field.Value));
    }
    initFields.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
    type.Methods.Add(initFields);
