    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ForbiddenMethodsAnalyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor("Forbidden",
                                                                                     "Don't use this method!",
                                                                                     "Use of the '{0}' method is not allowed",
                                                                                     "Forbidden.Stuff",
                                                                                     DiagnosticSeverity.Warning,
                                                                                     isEnabledByDefault: true,
                                                                                     description: "This method is forbidden");
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.InvocationExpression);
        }
        private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            var invocationExpression = (InvocationExpressionSyntax)context.Node;
            var memberAccessExpression = invocationExpression.Expression as MemberAccessExpressionSyntax;
            if (memberAccessExpression?.Name.ToString() == "EndsWith")
            {
                var memberSymbol = context.SemanticModel.GetSymbolInfo(memberAccessExpression).Symbol as IMethodSymbol;
                var containingType = memberSymbol.ContainingType;
                if (containingType.ContainingNamespace.Name == "System" && containingType.Name == "String")
                {
                    var diagnostic = Diagnostic.Create(Rule, invocationExpression.GetLocation(), memberAccessExpression.ToString());
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
    }
