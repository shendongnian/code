    // compile your piece of code to dll file
    Microsoft.CSharp.CSharpCodeProvider cSharpCodeProvider = new Microsoft.CSharp.CSharpCodeProvider();
    System.CodeDom.Compiler.CompilerParameters compilerParameters = new System.CodeDom.Compiler.CompilerParameters();
    compilerParameters.GenerateInMemory = true;
    compilerParameters.GenerateExecutable = false;
    System.CodeDom.Compiler.CompilerResults cResult = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, "using System; namespace Tables { 'put here your class definition' }");
    // then load your dll file, get type and object from class
    Assembly assembly = cResult.CompiledAssembly;
    Type myTableType = assembly.GetType("Tables.Tablename");
    var finalResult = Activator.CreateInstance(myTableType);
