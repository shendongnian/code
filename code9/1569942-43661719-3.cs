        var generator = SyntaxGenerator.GetGenerator(new AdhocWorkspace(), LanguageNames.CSharp);
        generator.InvocationExpression(
            generator.MemberAccessExpression(generator.IdentifierName("collection"), "Where"),
            generator.ValueReturningLambdaExpression(
                "x",
                generator.ValueEqualsExpression(
                    generator.MemberAccessExpression(generator.IdentifierName("x"), "Id"),
                    generator.LiteralExpression(2))))
