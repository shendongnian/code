    static int CompileAndRun(string[] code)
        {
            
            CompilerParameters CompilerParams = new CompilerParameters();
            string outputDirectory = Directory.GetCurrentDirectory();
            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";
            string[] references = { "System.dll", "System.Data.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, code);
            if (compile.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    text += "rn" + ce.ToString();
                }
                throw new Exception(text);
            }
            Module module = compile.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;
            if (module != null)
            {
                mt = module.GetType("CodeFromFile.CodeFromFile");
            }
            if (mt != null)
            {
                methInfo = mt.GetMethod("Add");
            }
            if (methInfo != null)
            {                
                return (int)methInfo.Invoke(null, new object[] { 5,10});
            }
            return null;
        }
