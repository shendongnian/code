    private async Task<Document> MakeVirtual(Document document, MethodDeclarationSyntax memberDeclaration, CancellationToken cancellationToken)
    {
        var methodDeclarationSyntax =
            memberDeclaration.WithModifiers(
                memberDeclaration.Modifiers.Add( SyntaxFactory.Token( SyntaxKind.VirtualKeyword ) ) );
    
        var oldRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait( false );
        var newRoot = oldRoot.ReplaceNode(memberDeclaration, methodDeclarationSyntax);
    
        return document.WithSyntaxRoot(newRoot);
    }
