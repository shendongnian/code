    foreach (var tree in context.SemanticModel.Compilation.SyntaxTrees)
    {
        var compilation = CSharpCompilation.Create("MyCompilation",
                        syntaxTrees: new[] { tree }, references: new List<MetadataReference>());
        var syntaxRoot = tree.GetRoot();
        var model = compilation.GetSemanticModel(tree);
        var targetMethod = syntaxRoot.DescendantNodes().OfType<MethodDeclarationSyntax>().FirstOrDefault(f => f.Identifier.ToString() == "Class name to find");
        if (targetMethod == null)
            continue;
        var typeInfo = model.GetTypeInfo(targetMethod.First().ParameterList.Parameters[i].ChildNodes().First());
        // Do any thing with typeInfo
    }
                   
