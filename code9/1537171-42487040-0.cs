    var selectorBody = selectorExpr.Body as ExpressionSyntax;
    var selectorParam = selectorExpr.Parameter.Identifier;
    IEnumerable<SyntaxToken> tokensToReplace = selectorBody.DescendantTokens()
                                                           .Where(token => Equals(token.Text, selectorParam.Text));
    selectorBody = selectorBody.ReplaceTokens(tokensToReplace, (t1, t2) => SyntaxFactory.IdentifierName("__").Identifier);
