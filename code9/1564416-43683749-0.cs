    public static IEnumerable<ISymbol> GetAllSymbols(CSharpCompilation compilation, SyntaxNode root)
    {
        var noDuplicates = new HashSet<ISymbol>();
        var model = compilation.GetSemanticModel(root.SyntaxTree);
        foreach (var node in root.DescendantNodesAndSelf())
        {
            switch (node.Kind())
            {
                case SyntaxKind.IdentifierName:
                case SyntaxKind.GenericName:
                    ISymbol symbol = model.GetSymbolInfo(node).Symbol;
                    if (symbol != null && noDuplicates.Add(symbol))
                    {
                        yield return symbol;
                    }
                    break;
            }
        }
    }
