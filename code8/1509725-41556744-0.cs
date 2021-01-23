    var newMethodNode = oldMethodNode.WithModifiers(
                        SyntaxFactory.TokenList(
                            new []{
                                SyntaxFactory.Token(
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.Trivia(
                                         SyntaxFactory.DocumentationCommentTrivia( /*...*/ ) )))
                        }));
    root.ReplaceNode (oldMethodNode, newMethodNode);
