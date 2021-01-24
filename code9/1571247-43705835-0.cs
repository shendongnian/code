    public static Assembly CompileAssembly(string[] sourceFiles, string outputAssemblyPath)
            {
                var codeProvider = new CSharpCodeProvider();
    
                var compilerParameters = new CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = false,
                    OutputAssembly = outputAssemblyPath
                };
    
                // Add CSharpSimpleScripting.exe as a reference to Scripts.dll to expose interfaces
                //compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
    
                var result = codeProvider.CompileAssemblyFromFile(compilerParameters, sourceFiles); // Compile
                if (result.Errors.Count > 0)
                {
                    MessageBox.Show(@"Error Occured");
                }
                else
                {
                    return result.CompiledAssembly;
                    
                }
                return null;
            }
