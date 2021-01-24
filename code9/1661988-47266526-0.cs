    List<String> references = new List<string>();
    String mscorlib = Path.Combine(              
        Environment.GetFolderPath(Environment.SpecialFolder.Windows),
        @"Microsoft.NET\Framework\v2.0.50727\mscorlib.dll"
    );
    references.Add(mscorlib);
    // Add other references...
    
    var provider = new CSharpCodeProvider(new Dictionary<String,String> {{"CompilerVersion", "v4.0"}});
    var parameters = new CompilerParameters(references.ToArray(), "MyApp.exe");
    parameters.GenerateExecutable = true;
    parameters.CompilerOptions = "/nostdlib";              
    
    var results = provider.CompileAssemblyFromSource(parameters,
        @"using System;
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(""CLR Version: "" + Environment.Version);
            }
        }");
