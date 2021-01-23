    var testDocumentation = SyntaxFactory.DocumentationCommentTrivia(
        SyntaxKind.SingleLineDocumentationCommentTrivia,
        SyntaxFactory.List<XmlNodeSyntax>(
            new XmlNodeSyntax[]{
                SyntaxFactory.XmlText()
                .WithTextTokens(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.XmlTextLiteral(
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.DocumentationCommentExterior("///")),
                            " ",
                            " ",
                            SyntaxFactory.TriviaList()))),
                SyntaxFactory.XmlElement(
                    SyntaxFactory.XmlElementStartTag(
                        SyntaxFactory.XmlName(
                            SyntaxFactory.Identifier("summary"))),
                    SyntaxFactory.XmlElementEndTag(
                        SyntaxFactory.XmlName(
                            SyntaxFactory.Identifier("summary"))))
                .WithContent(
                    SyntaxFactory.SingletonList<XmlNodeSyntax>(
                        SyntaxFactory.XmlText()
                        .WithTextTokens(
                            SyntaxFactory.TokenList(
                                SyntaxFactory.XmlTextLiteral(
                                    SyntaxFactory.TriviaList(),
                                    "test",
                                    "test",
                                    SyntaxFactory.TriviaList()))))),
                SyntaxFactory.XmlText()
                .WithTextTokens(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.XmlTextNewLine(
                            SyntaxFactory.TriviaList(),
                            "\n",
                            "\n",
                            SyntaxFactory.TriviaList())))}));
