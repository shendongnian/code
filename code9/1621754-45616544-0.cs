    var semanticModel = await document.GetSemanticModelAsync()
    var typeInfo = semanticModel.GetTypeInfo(
                ((MemberAccessExpressionSyntax)invocationExpressionSyntaxNode.Expression);
    var nameSpace = ((INamedTypeSymbol)typeInfo.Type).ContainingNamespace;
    var nameSpaceName = nameSpace.Name;
	
