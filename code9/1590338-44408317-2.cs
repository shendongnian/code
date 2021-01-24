    HashSet<ITypeSymbol> types = new HashSet<ITypeSymbol>();
    
    foreach (ObjectCreationExpressionSyntax node in creations)
    {
        var typeSymbol = semanticModel.GetTypeInfo(node).Type;
        types.Add(typeSymbol);
    }
    int numberOfTypes = types.Count;
