	var attribute = ;
	var newParam = param.WithAttributeLists(SyntaxFactory.SingletonList<AttributeListSyntax>(
        SyntaxFactory.AttributeList(
            SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
                SyntaxFactory.Attribute(SyntaxFactory.IdentifierName("NotNull"), null)))));
    var root = await document.GetSyntaxRootAsync();
	var newRoot = root.ReplaceNode(param, newParam);    
    var newDocument = document.WithSyntaxRoot(newRoot);
    return newDocument;
