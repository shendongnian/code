    // Read the module and get the relevant type
    var assemblyPath = $"{Environment.CurrentDirectory}\\ClassLibrary1.dll";
    var module = ModuleDefinition.ReadModule(assemblyPath);
    var type = module.Types.Single(t => t.Name == "AnEntityVirtual");
    // Get the method to rewrite
    var myDataProperty = type.Properties.Single(prop => prop.Name == "MyData");
    var isModifiedSetMethod = type.Properties.Single(prop => prop.Name == "IsModified").SetMethod;
    var setMethodBody = myDataProperty.SetMethod.Body;
    // Initilize before rewriting (clear pre instructions, create locals and init them)
    setMethodBody.Instructions.Clear();
    var localDef = new VariableDefinition(module.TypeSystem.Boolean);
    setMethodBody.Variables.Add(localDef);
    setMethodBody.InitLocals = true;
     // Get fields\methos to use in the new method body
     var propBackingField = type.Fields.Single(field => field.Name == $"<{myDataProperty.Name}>k__BackingField");
    var equalMethod =
                myDataProperty.PropertyType.Resolve().Methods.FirstOrDefault(method => method.Name == "Equals") ??
                module.ImportReference(typeof(object)).Resolve().Methods.Single(method => method.Name == "Equales");
    var equalMethodReference = module.ImportReference(equalMethod);
    // Start the rewriting
    var ilProcessor = setMethodBody.GetILProcessor();
            
    // First emit a Ret instruction. This is beacause we want a label to jump if the values are equals
    ilProcessor.Emit(OpCodes.Ret);
    var ret = setMethodBody.Instructions.First();
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Ldarg_0)); // load 'this'
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Ldfld, propBackingField)); // load backing field
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Ldarg_1)); // load 'value'
    ilProcessor.InsertBefore(ret, ilProcessor.Create(equalMethod.IsStatic ? OpCodes.Call : OpCodes.Callvirt, equalMethodReference)); // call equals
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Stloc_0)); // store result
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Ldloc_0)); // load result
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Brtrue_S, ret)); // check result and jump to Ret if are equals
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Ldarg_0)); // load 'this'
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Ldc_I4_1)); // load 1 ('true')
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Call, isModifiedSetMethod)); // set IsModified to 'true'
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Ldarg_0)); // load this
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Ldarg_1)); // load 'value'
    ilProcessor.InsertBefore(ret, ilProcessor.Create(OpCodes.Stfld, propBackingField)); // store 'value' in backing field
    // here you can call to Notify or whatever you want
    module.Write(assemblyPath.Replace(".dll", "_new") + ".dll"); // save the new assembly
