    private static List<BaseItem> loadItems(string fromCode)
    {
        CodeDomProvider codeProvider = new CSharpCodeProvider();
    
        // add compiler parameters
        CompilerParameters compilerParams = new CompilerParameters();
        compilerParams.CompilerOptions = "/target:library /optimize";
        compilerParams.GenerateExecutable = false;
        compilerParams.GenerateInMemory = true;
        compilerParams.IncludeDebugInformation = false;
        compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
        compilerParams.ReferencedAssemblies.Add("System.dll");
        compilerParams.ReferencedAssemblies.Add("MyLibrary.dll");
    
        // compile the code
        CompilerResults results = codeProvider.CompileAssemblyFromSource(compilerParams, fromCode);
        var items = new List<BaseItem>();
        foreach (var itemType in results.CompiledAssembly.DefinedTypes)
        {
            ConstructorInfo ctor = itemType.GetConstructor(Type.EmptyTypes);
            object instance = ctor.Invoke(null);
            items.Add(instance as BaseItem);
        }
        return items;
    }
