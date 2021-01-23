    namespace ScriptingExample
	{
	    public static class ScriptingEx
	    {
	        public static void StartScript(ScriptingInterface.IServiceProvider serviceProvider)
	        {
	            string path = @"TestScript1.cs";
	            // Open the file to read from.
	            string readText = File.ReadAllText(path);
	            Assembly compiledScript = CompileCode(readText);
	            if (compiledScript != null)
	            {
	                RunScript(serviceProvider, compiledScript);
	            }
	        }
	        static Assembly CompileCode(string code)
	        {
	            Microsoft.CSharp.CSharpCodeProvider csProvider = new Microsoft.CSharp.CSharpCodeProvider();
	            CompilerParameters options = new CompilerParameters();
	            options.GenerateExecutable = false; 
	            options.GenerateInMemory = true; 
	            
                    options.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
                //Add references to ScriptingInterface.dll
	            String pathToScriptingInterfaceDll = Path.Combine(Environment.CurrentDirectory, "ScriptingInterface.dll");
	            options.ReferencedAssemblies.Add(pathToScriptingInterfaceDll);
	            // Compile our code
	            CompilerResults result;
	            result = csProvider.CompileAssemblyFromSource(options, code);
	            if (result.Errors.HasErrors)
	            {
	                // Report back to the user that the script has errored
	                Console.WriteLine("Script has errored");
	                for (int i = 0; i < result.Errors.Count; i++)
	                {
	                    Console.WriteLine("Error {0}: {1}", i+1, result.Errors[i]);
	                }
	                return null;
	            }
	            if (result.Errors.HasWarnings)
	            {
	                Console.WriteLine("Script has warnings");
	            }
	            return result.CompiledAssembly;
	        }
	        static void RunScript(ScriptingInterface.IServiceProvider serviceProvider, Assembly script)
	        {
	            foreach (Type type in script.GetExportedTypes())
	            {
	                foreach (Type iface in type.GetInterfaces())
	                {
	                    if (iface == typeof(ScriptingInterface.IScriptType1))
	                    {
	                        ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
	                        if (constructor != null && constructor.IsPublic)
	                        {
	                            ScriptingInterface.IScriptType1 scriptObject = constructor.Invoke(null) as ScriptingInterface.IScriptType1;
	                            if (scriptObject != null)
	                            {
	                                //Lets run our script and display its results
	                                MessageBox.Show(scriptObject.RunScript(50));
	                            }
	                        }
	                    }
	                }
	            }
	        }
	        public static void TestExternalCall1()
	        {
	            Console.WriteLine("Called successfully!");
	        }
	    }
	}
