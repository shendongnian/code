    foreach (var method in type.Methods)
    {
        foreach (var parameter in method.Parameters)
        {
            foreach (var attribute in parameter.CustomAttributes)
            {
                if (!validators.Contains(attribute.AttributeType))
                    continue;
                var field = newFields[attribute.AttributeType];
                var validationMethod = field.FieldType.Resolve().Methods.First(m => m.Name == "Validate");
                method.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Ldarg_0));
                method.Body.Instructions.Insert(1, Instruction.Create(OpCodes.Ldfld, field));
                method.Body.Instructions.Insert(2, Instruction.Create(OpCodes.Ldarg_S, parameter));
                method.Body.Instructions.Insert(3, Instruction.Create(OpCodes.Callvirt, validationMethod));
            }
        }
    }
