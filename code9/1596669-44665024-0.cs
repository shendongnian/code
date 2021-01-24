    var implementedInterfaceTypeSyntax = extractedInterfaceSymbol.TypeParameters.Any()
                ? SyntaxFactory.GenericName(
                    SyntaxFactory.Identifier(extractedInterfaceSymbol.Name),
                    SyntaxFactory.TypeArgumentList(SyntaxFactory.SeparatedList(extractedInterfaceSymbol.TypeParameters.Select(p => SyntaxFactory.ParseTypeName(p.Name)))))
                : SyntaxFactory.ParseTypeName(extractedInterfaceSymbol.Name);
    var baseList = typeDeclaration.BaseList ?? SyntaxFactory.BaseList();
    var updatedBaseList = baseList.WithTypes(SyntaxFactory.SeparatedList(baseList.Types.Union(new[] { SyntaxFactory.SimpleBaseType(implementedInterfaceTypeSyntax) })));
