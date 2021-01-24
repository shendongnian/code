    var classDeclarationSyntaxs = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
    foreach ( var classDeclarationSyntax in classDeclarationSyntaxs )
    {
        var propertyDeclarationSyntaxs = classDeclarationSyntax.Members.OfType<PropertyDeclarationSyntax>();
        var barTypePropertyDeclarationSyntax = propertyDeclarationSyntaxs.FirstOrDefault( p => p.Identifier.Text == "BarType" );
        if ( barTypePropertyDeclarationSyntax != null )
        {
            var returnStatementSyntax = barTypePropertyDeclarationSyntax.DescendantNodes().OfType<ReturnStatementSyntax>().FirstOrDefault();
            if ( returnStatementSyntax != null )
            {
                var typeOfExpressionSyntax = returnStatementSyntax.ChildNodes().OfType<TypeOfExpressionSyntax>().FirstOrDefault();
                if ( typeOfExpressionSyntax != null )
                {
                    var symbolInfo = semanticModel.GetSymbolInfo( typeOfExpressionSyntax.Type );
                    var symbolInfoSymbol = symbolInfo.Symbol;
                }
            }
        }
    }
