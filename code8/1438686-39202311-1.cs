    // ObjectCreationExpression node == ...;
    // SemanticModel model = ...;
    var symbol = model.GetSymbolInfo(node).Symbol; // the constructor symbol
    var type = symbol.ContainingType; // the class symbol
    var isFromSource = type.DeclaringSyntaxReferences.Length > 0
    
