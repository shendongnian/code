        var lambdaMethod = new CodeMemberMethod
        {
            Name = "IsIdTwo",
            Parameters =
            {
                new CodeParameterDeclarationExpression(
                    new CodeTypeReference("YourEntityType"), "x")
            },
            Statements =
            {
                new CodeMethodReturnStatement(
                    new CodeBinaryOperatorExpression(
                        new CodePropertyReferenceExpression(
                            new CodeVariableReferenceExpression("x"), "Id"),
                        CodeBinaryOperatorType.ValueEquality,
                        new CodePrimitiveExpression(2)))
            }
        };
        …
        new CodeMethodInvokeExpression(
            collectionExpression, "Where", new CodeMethodReferenceExpression(null, "IsIdTwo"))
