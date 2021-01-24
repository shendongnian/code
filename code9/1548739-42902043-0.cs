     context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
            private static void AnalyzeSymbol(SyntaxNodeAnalysisContext context)
            {
                var node = (ObjectCreationExpressionSyntax)context.Node;
    
                if (node != null && node.Type != null && node.Type is IdentifierNameSyntax)
                {
                    var type = (IdentifierNameSyntax)node.Type;
    
                    var symbol = (INamedTypeSymbol)context.SemanticModel.GetSymbolInfo(type).Symbol;
                    var isIService = IsInheritedFromIService(symbol);
    
                    if (isIService )
                    {
                       ... //Check you logic
                        context.ReportDiagnostic(diagnostic);
                    }
                }
            }
        private static bool IsInheritedFromIService(ITypeSymbol symbol)
        {
            bool isIService = false;
            var lastParent = symbol;
            if (lastParent != null)
            {
                while (lastParent.BaseType != null)
                {
                    if (lastParent.BaseType.Name == "IService")
                    {
                        isIService = true;
                        lastParent = lastParent.BaseType;
                        break;
                    }
                    else
                    {
                        lastParent = lastParent.BaseType;
                    }
                }
            }
            return isIService ;
        }
