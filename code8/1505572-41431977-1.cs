    var compilationUnit = SyntaxFactory.CompilationUnit()
        .AddMembers(SyntaxFactory.ClassDeclaration("MyClass").AddMembers(
            SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                    "Main")
                .WithBody(SyntaxFactory.Block())))
        .NormalizeWhitespace();
    CSharpCompilation compilation = CSharpCompilation.Create(
        assemblyName: "MyAssembly",
        syntaxTrees: new[] { compilationUnit.SyntaxTree },
        references: references,
        options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
    );
