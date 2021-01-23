    CompilerParameters opts = new CompilerParameters();
    			
    opts.OutputAssembly = <Destination FileName>;
    opts.ReferencedAssemblies.AddRange(<needed references>);
    //set other options;			
    
    var codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
    var results = codeProvider.CompileAssemblyFromFile(opts, <Your script source files>);
    //check that there's no errors in the results.Errors
