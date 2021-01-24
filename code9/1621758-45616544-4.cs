    var semanticModel = await document.GetSemanticModelAsync()
	var name = (GenericNameSyntax)((MemberAccessExpressionSyntax)node.Expression).Name;
	var typeInfo = semanticModel.GetTypeInfo(name.TypeArgumentList.Arguments.First());
	var nameSpace = ((INamedTypeSymbol)typeInfo.Type).ContainingNamespace;
	var nameSpaceName = nameSpace.Name;
	
