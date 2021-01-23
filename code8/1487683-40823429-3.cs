    static IEnumerable<ISymbol> GetTeeSymbols(SyntaxTree tree, SemanticModel model)
    {
        return tree.GetRoot().
                 DescendantNodesAndSelf().
                 Select(node => model.GetSymbolInfo(node).Symbol ?? model.GetDeclaredSymbol(node)).Where(info => info != null);
    }
