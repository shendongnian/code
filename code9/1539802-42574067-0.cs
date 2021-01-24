    using (var assemblyDefinition = AssemblyDefinition.ReadAssembly("assemblyPath")) {
        var module = AssemblyDefinition.MainModule;
        
        //Select the type you need to open for addition
        var typeDef = module.Types.First(td => td.Name == "footer");
        
        //Add your MethodDefinition
        typeDef.Methods.Add(your_method_definition);
        //Write the assembly back
        assemblyDefinition.Write();
    }
