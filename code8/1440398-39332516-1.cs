	var attribute = SyntaxFactory.AttributeList(
	    SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
		    SyntaxFactory.Attribute(SyntaxFactory.IdentifierName("NotNull"), null)));
	var newParam = param.WithAttributeLists(param.AttributeLists.Add(attribute));
    var root = await document.GetSyntaxRootAsync();
	var newRoot = root.ReplaceNode(param, newParam);    
    var newDocument = document.WithSyntaxRoot(newRoot);
    return newDocument;
