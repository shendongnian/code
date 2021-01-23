    var identifier = 
        (node.Expression as MemberAccessExpressionSyntax)?.Expression as IdentifierNameSyntax;
    if (identifier != null && identifier.Identifier.Text == "EntityService")
    {
        // process the invocation expression
    }
