    public PropertyDeclarationSyntax ConvertToResourceProperty(string resouceClassIdentifier, string fieldName, string resourceKey, CSharpSyntaxNode field)
    {
        var stringType = SyntaxFactory.ParseTypeName("string");
        var resourceClassName = SyntaxFactory.IdentifierName(resouceClassIdentifier);
        var resourceKeyName = SyntaxFactory.IdentifierName(resourceKey);
        var memberaccess = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, resourceClassName, resourceKeyName);
        var propertyLambda = SyntaxFactory.ArrowExpressionClause(memberaccess);
        var propertyDeclaration = SyntaxFactory.PropertyDeclaration(new SyntaxList<AttributeListSyntax>(), new SyntaxTokenList(), 
                                                                    stringType, null, SyntaxFactory.Identifier(fieldName), null, 
                                                                    propertyLambda, null, SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                                                                            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), 
                                                                        SyntaxFactory.Token(SyntaxKind.StaticKeyword)).WithAdditionalAnnotations(Formatter.Annotation).NormalizeWhitespace();
            
        return propertyDeclaration.WithTrailingTrivia(SyntaxFactory.ElasticCarriageReturnLineFeed)
                    .WithLeadingTrivia(field.GetLeadingTrivia().ToArray())
                    .WithAdditionalAnnotations(Simplifier.Annotation);
    }
