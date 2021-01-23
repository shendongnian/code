    // First get the relevant method (or any other parent block depending in the case)
    var method = root.DescendantNodes().OfType<MethodDeclarationSyntax>().First();
    // Then, you can write method similar to this
    static SyntaxTrivia GetConditionalDirectiveTrivia(SyntaxNode node, SyntaxKind kind)
    {
        foreach (SyntaxNode syntaxNode in node.DescendantNodes())
        {
            var trivia = syntaxNode.GetLeadingTrivia().FirstOrDefault(t => t.Kind() == kind);
            if (trivia != default(SyntaxTrivia))
                return trivia;
            GetConditionalDirectiveTrivia(syntaxNode, kind);
        }
        return default(SyntaxTrivia);
    }
