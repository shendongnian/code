    foreach (var objectCreationExpressionSyntax in objectCreationExpressionSyntaxs)
    {
        IdentifierNameSyntax ins = (IdentifierNameSyntax)objectCreationExpressionSyntax.Type;
        var id = ins.Identifier;
        Console.WriteLine(id.ValueText);
    }
