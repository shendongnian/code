    private static bool IsAssignmentBad(AssignmentExpressionSyntax assignmentNode)
    {
        if (!assignmentNode.IsKind(SyntaxKind.SimpleAssignmentExpression))
        {
            return false;
        }
        var lhs = assignmentNode.Left;
        if (!lhs.IsKind(SyntaxKind.IdentifierName))
        {
            return false;
        }
        var rhs = assignmentNode.Right;
        if (!rhs.IsKind(SyntaxKind.IdentifierName))
        {
            return false;
        }
        return SyntaxFactory.AreEquivalent(lhs, rhs);
    }
