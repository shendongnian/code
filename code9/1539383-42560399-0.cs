    private void GetSymbolsTest(ref Project project, ref MetadataReference metaRef)
        {
            if (!project.MetadataReferences.Contains(metaRef))
                throw new DllNotFoundException("metadatarefence not in project");
            var compilation = Explorer.MethodProject[MethodDSyntax].GetCompilationAsync().Result;
            var metaRefName = Path.GetFileNameWithoutExtension(metaRef.Display);
 
            SymbolCollector symCollector = new SymbolCollector();
            symCollector.Find(compilation.GlobalNamespace, metaRefName);
            Console.WriteLine($"Classes found: {symCollector.Classes.Count}");
            Console.WriteLine($"Methods found: {symCollector.Methods.Count}");
        }
    public class SymbolCollector
    {
        public HashSet<IMethodSymbol> Methods { get; private set; } = new HashSet<IMethodSymbol>();
        public HashSet<INamedTypeSymbol> Classes { get; private set; } = new HashSet<INamedTypeSymbol>();
        public void Find(INamespaceSymbol namespaceSymbol, string assemblyRefName)
        {
            foreach (var type in namespaceSymbol.GetTypeMembers())
            {
                if (String.Equals(type.ContainingAssembly.Name, assemblyRefName, StringComparison.CurrentCultureIgnoreCase))
                    Find(type);
            }
            foreach (var childNs in namespaceSymbol.GetNamespaceMembers())
            {
                Find(childNs, assemblyRefName);
            }
        }
        private void Find(INamedTypeSymbol type)
        {
            if (type.Kind == SymbolKind.NamedType)
                Classes.Add(type);
            foreach (var member in type.GetMembers())
            {
                if (member.Kind == SymbolKind.Method)
                    Methods.Add(member as IMethodSymbol);
            }
            foreach (var nested in type.GetTypeMembers())
            {
                Find(nested);
            }
        }
    }
