    var codeProvider = new CSharpCodeProvider();
    var compilerParameters = new CompilerParameters
    {
        GenerateExecutable = false,
        GenerateInMemory = false,
        IncludeDebugInformation = true,
        OutputAssembly = outputAssemblyPath
    };
    // Add CSharpSimpleScripting.exe as a reference to Scripts.dll to expose interfaces
    compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
    var result = codeProvider.CompileAssemblyFromFile(compilerParameters, sourceFiles); // Compile
    return result.CompiledAssembly;
}
