    var methods = memcls
        .DescendantNodes()
        .OfType<BaseMethodDeclarationSyntax>()
        .ToList();
    foreach (var method in methods)
    {
        var identifier = IdentifierVisitor.Instance.Visit(method);
        if (!identifier.IsKind(SyntaxKind.None))
        {
            Console.WriteLine(identifier.Text);
        }
    }
