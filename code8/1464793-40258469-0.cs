          CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = "Per.dll";
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, "public class PersonVM{ " + "public int id{get;set;}" +
                "public string Name{get;set;}" + " }");
            Assembly assembly = Assembly.LoadFrom("Per.dll");
            var type = assembly.GetType("PersonVM");
            object obj = Activator.CreateInstance(type, true);
            return View(obj);
 
