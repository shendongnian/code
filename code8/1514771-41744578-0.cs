    if (methodSymbol.ReturnType.Equals(syntaxNodeAnalysisContext.SemanticModel.Compilation.GetTypeByMetadataName(typeof(Task).FullName)))
    {
        // For all such symbols, produce a diagnostic.
        var diagnostic = Diagnostic.Create(Rule, node.GetLocation(), methodSymbol.ToDisplayString());
    
        syntaxNodeAnalysisContext.ReportDiagnostic(diagnostic);
    }
    if (((INamedTypeSymbol) methodSymbol.ReturnType).IsGenericType && ((INamedTypeSymbol) methodSymbol.ReturnType).BaseType.Equals(syntaxNodeAnalysisContext.SemanticModel.Compilation.GetTypeByMetadataName(typeof(Task).FullName)))
    {
        // For all such symbols, produce a diagnostic.
        var diagnostic = Diagnostic.Create(Rule, node.GetLocation(), methodSymbol.ToDisplayString());
    
        syntaxNodeAnalysisContext.ReportDiagnostic(diagnostic);
    }
