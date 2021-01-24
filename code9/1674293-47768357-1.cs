    var compilerResults = new CSharpCodeProvider()
        .CompileAssemblyFromSource(
            new CompilerParameters
            {
                GenerateInMemory = true,
                ReferencedAssemblies =
                {
                    "System.dll",
                    Assembly.GetExecutingAssembly().Location
                }
            },
            bar1Code);
