    var methodDeclarations =
        tree.GetRoot()
            .DescendantNodes()
            .Where(c => c is MethodDeclarationSyntax || c is ConstructorDeclarationSyntax)
            .Cast<dynamic>();
    
    foreach (var memmeth in methodDeclarations)
    {
        // Run-time checking so no syntax error
        Console.WriteLine(memmeth.Identifier);
    }
