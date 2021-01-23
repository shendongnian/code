    public class Rewritter : CSharpSyntaxRewriter
    {
        private readonly SemanticModel SemanticModel;
        public Rewritter(SemanticModel semanticModel)
        {
            SemanticModel = semanticModel;
        }
        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var symbol = SemanticModel.GetSymbolInfo(node).Symbol as IMethodSymbol;
            // symbol could be null, e.g. when invoking a delegate
            if (symbol == null)
            {
                return base.VisitInvocationExpression(node);
            }
            // symbol must be called Build and have 0 parameters
            if (symbol.Name != "Build" ||
                symbol.Parameters.Length != 0)
            {
                return base.VisitInvocationExpression(node);
            }
            // TODO you might want to check that the parent is not an invocation of .WithOption("addnewline") already
            // symbol must be a method on the type "Fluent.FluentSample"
            var type = symbol.ContainingType;
            if (type.Name != "FluentSample" || type.ContainingSymbol.Name != "Fluent")
            {
                return base.VisitInvocationExpression(node);
            }
            // TODO you may want to add a check that the containing symbol is a namespace, and that its containing namespace is the global namespace
            // we have the right one, so return the syntax we want
            return
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        node,
                        SyntaxFactory.IdentifierName("WithOption")),
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.Argument(
                                SyntaxFactory.LiteralExpression(
                                    SyntaxKind.StringLiteralExpression,
                                    SyntaxFactory.Literal("addnewline"))))));
        }
    }
