    // Culture information has to be part of the newly created assembly.
    var assemblyAttributesAsCode = @"
        using System.Reflection; 
        [assembly: AssemblyCulture(""de"")]";
    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    CompilerResults results = codeProvider.CompileAssemblyFromSource(
        parameters, 
        assemblyAttributesAsCode
    );
