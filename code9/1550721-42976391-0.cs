    var reference = MetadataReference.CreateFromFile(dllPath);
    var compilation = CSharpCompilation.Create(null).AddReferences(reference);
    var assemblySymbol = (IAssemblySymbol)compilation.GetAssemblyOrModuleSymbol(reference);
    Write(assemblySymbol.GlobalNamespace);
    void Write(INamespaceOrTypeSymbol symbol)
    {
        if (symbol is ITypeSymbol)
            Console.WriteLine(symbol);
        foreach (var memberSymbol in symbol.GetMembers().OfType<INamespaceOrTypeSymbol>())
        {
            Write(memberSymbol);
        }
    }
