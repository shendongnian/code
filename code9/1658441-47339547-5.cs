    var classDeclarationSyntaxs = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
    foreach ( var classDeclarationSyntax in classDeclarationSyntaxs )
    {
        var typeOfSyntaxWalker = new TypeOfSyntaxWalker( semanticModel );
        typeOfSyntaxWalker.VisitClassDeclaration( classDeclarationSyntax );
        var symbolInfoSymbol = typeOfSyntaxWalker.SymbolInfoSymbol;
    }
