            string sourceCode = @"
                public class Test
    {
        public void Hello()
        {
            Console.Write(@"Hello");
        }
    }";
            var compParms = new CompilerParameters{
                GenerateExecutable = false, 
                GenerateInMemory = true
            };
            var csProvider = new CSharpCodeProvider();
            CompilerResults compilerResults = 
                csProvider.CompileAssemblyFromSource(compParms, sourceCode);
            object typeInstance = 
                compilerResults.CompiledAssembly.CreateInstance("Test");
            MethodInfo mi = typeInstance.GetType().GetMethod("Hello");
            mi.Invoke(typeInstance, null); 
            Console.ReadLine();
