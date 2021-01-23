    IEnumerable<INamespaceSymbol> GetAllNamespaces(INamespaceSymbol namespaceSymbol)
    {
        foreach (INamespaceSymbol symbol in namespaceSymbol.GetNamespaceMembers())
        {
            yield return symbol;
            foreach (INamespaceSymbol childSymbol in GetAllNamespaces(symbol))
            {
                yield return symbol;
            }
        }
    }
    
    var allNamespaceNodes = new List<NamespaceDeclarationSyntax>();
    foreach (INamespaceSymbol namespaceSymbol in GetAllNamespaces(compilation.GlobalNamespace))
    {
        allNamespaceNodes.AddRange(from syntaxReference in namespaceSymbol.DeclaringSyntaxReferences
                                    select syntaxReference.GetSyntax(cancellationToken) as NamespaceDeclarationSyntax);
    }
