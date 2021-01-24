           static Type GetMeAType( string myTypeName, string myStringPropertyName ) {
    
                string codeToCompile = "using System; public class " + myTypeName + " {public string " +
                                       myStringPropertyName + " { get; set; } }";
                string[] references = { "System.dll", "System.Core.dll" };
    
                CompilerParameters compilerParams = new CompilerParameters();
    
                compilerParams.GenerateInMemory = true;
                compilerParams.TreatWarningsAsErrors = false;
                compilerParams.GenerateExecutable = false;
                compilerParams.CompilerOptions = "/optimize";
                compilerParams.ReferencedAssemblies.AddRange( references );
    
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerResults compile = provider.CompileAssemblyFromSource( compilerParams, codeToCompile );
                Module dynamicModule = compile.CompiledAssembly.GetModules()[ 0 ];
                var type = dynamicModule.GetType( myTypeName );
    
                return type;
    
            }
