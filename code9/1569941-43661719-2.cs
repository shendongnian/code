        using Microsoft.CodeAnalysis;
        using Microsoft.CodeAnalysis.CSharp;
        using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
        …
        InvocationExpression(
            MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName("collection"),
                IdentifierName("Where")),
            ArgumentList(
                SingletonSeparatedList(
                    Argument(
                        SimpleLambdaExpression(
                            Parameter(Identifier("x")),
                            BinaryExpression(
                                SyntaxKind.EqualsExpression,
                                MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    IdentifierName("x"),
                                    IdentifierName("Id")),
                                LiteralExpression(
                                    SyntaxKind.NumericLiteralExpression, Literal(2))))))))
