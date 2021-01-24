    // Step 1: load assembly to memory
    var an = AssemblyName.GetAssemblyName(tbAssemblyLocation.Text);
    var assembly = Assembly.Load(an);
    // Step 2: get type from the assembly by name
    var type = assembly.GetType("MSgBOxDllCS.Funcs");
    // Step 3: get method of the type
    var method = type.GetMethod("CallMessageBox");
    // Step 4: create instance of the type
    var funcs = Activator.CreateInstance(type);
    // Step 5: invoke the instance method
    method.Invoke(funcs, null);
