    var newMethodNode = oldMethodNode.WithModifiers(
        SyntaxFactory.TokenList(
            new []{
                SyntaxFactory.Token(
                    SyntaxFactory.TriviaList(
                        SyntaxFactory.Trivia(testDocumentation)), // xmldoc
                        SyntaxKind.PublicKeyword, // original 1st token
                        SyntaxFactory.TriviaList()),
                SyntaxFactory.Token(SyntaxKind.StaticKeyword)}))
    
    root.ReplaceNode (oldMethodNode, newMethodNode);
