    private async Task<bool> IsMentionedInDisposeCallAsync(SyntaxNodeAnalysisContext context, FieldDeclarationSyntax fieldDeclarationSyntax)
    {
        foreach (var variableDeclaratorSyntax in fieldDeclarationSyntax.Declaration.Variables)
        {
            var declaredSymbol = context.SemanticModel.GetDeclaredSymbol(variableDeclaratorSyntax);
            if (declaredSymbol is IFieldSymbol fieldSymbol)
            {
                var isDisposeable = CheckIsTypeIDisposeable(fieldSymbol.Type as INamedTypeSymbol);
                //              SymbolFinder.FindReferencesAsync()
                var b = fieldSymbol.Locations;
                //              context.SemanticModel.Compilation.
            }
        }
        return false;
    }
    private string fullQualifiedAssemblyNameOfIDisposeable = typeof(IDisposable).AssemblyQualifiedName;
    private bool CheckIsTypeIDisposeable(INamedTypeSymbol type)
    {
        // Identify the IDisposable class. You can use any method to do this here
        // A type.ToDisplayString() == "System.IDisposable" might do it for you
        if(fullQualifiedAssemblyNameOfIDisposeable == 
            type.ToDisplayString() + ", " + type.ContainingAssembly.ToDisplayString())
        {
            return true;
        }
        if(type.BaseType != null)
        {
            if (CheckIsTypeIDisposeable(type.BaseType))
            {
                return true;
            }
        }
        foreach(var @interface in type.AllInterfaces)
        {
            if (CheckIsTypeIDisposeable(@interface))
            {
                return true;
            }
        }
        return false;
    }
