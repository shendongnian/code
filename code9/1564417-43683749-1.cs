    public static IEnumerable<ISymbol> GetAllSymbols(CSharpCompilation compilation, SyntaxNode root)
    {
        var noDuplicates = new HashSet<ISymbol>();
        var model = compilation.GetSemanticModel(root.SyntaxTree);
        foreach (var node in root.DescendantNodesAndSelf())
        {
            switch (node.Kind())
            {
                case SyntaxKind.ExpressionStatement:
                case SyntaxKind.InvocationExpression:
                    break;
                default:
                    ISymbol symbol = model.GetSymbolInfo(node).Symbol;
                    if (symbol != null)
                    {
                        if (noDuplicates.Add(symbol))
                            yield return symbol;
                    }
                    break;
            }
        }
    }
