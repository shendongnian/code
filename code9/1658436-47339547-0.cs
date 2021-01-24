    var classDeclarationSyntaxs = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
    foreach ( var classDeclarationSyntax in classDeclarationSyntaxs )
    {
        var propertyDeclarationSyntaxs = classDeclarationSyntax.Members.OfType<PropertyDeclarationSyntax>();
        foreach ( var propertyDeclarationSyntax in propertyDeclarationSyntaxs )
        {
            var typeOfExpressionSyntax = propertyDeclarationSyntax.DescendantNodes()
                .OfType<TypeOfExpressionSyntax>().FirstOrDefault();
            if ( typeOfExpressionSyntax != null )
            {
                var symbolInfo = semanticModel.GetSymbolInfo( typeOfExpressionSyntax.Type );
                var symbolInfoSymbol = symbolInfo.Symbol;
            }
        }
    }
