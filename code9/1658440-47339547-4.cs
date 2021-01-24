    public class TypeOfSyntaxWalker : CSharpSyntaxWalker
    {
        private readonly SemanticModel _semanticModel;
    
        public ISymbol SymbolInfoSymbol { get; private set; }
    
        public TypeOfSyntaxWalker( SemanticModel semanticModel )
        {
            _semanticModel = semanticModel;
        }
    
        public override void VisitTypeOfExpression( TypeOfExpressionSyntax typeOfExpressionSyntax )
        {
            var parent = typeOfExpressionSyntax.Parent;
            if ( parent.Kind() == SyntaxKind.ReturnStatement )
            {
                var propertyDeclarationSyntax = parent.FirstAncestorOrSelf<PropertyDeclarationSyntax>();
                if ( propertyDeclarationSyntax != null &&
                        propertyDeclarationSyntax.Identifier.ValueText == "BarType" )
                {
                    var symbolInfo = _semanticModel.GetSymbolInfo( typeOfExpressionSyntax.Type );
                    SymbolInfoSymbol = symbolInfo.Symbol;
                }
            }
            base.VisitTypeOfExpression( typeOfExpressionSyntax );
        }
    }
