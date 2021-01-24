    private static IEnumerable<string> GetReferences(string projectFileName)
    {
        var projectInstance = new ProjectInstance(projectFileName);
        var result = BuildManager.DefaultBuildManager.Build(
            new BuildParameters(),
            new BuildRequestData(projectInstance, new[]
            {
                "ResolveProjectReferences",
                "ResolveAssemblyReferences"
            }));
        IEnumerable<string> GetResultItems(string targetName)
        {
            var buildResult = result.ResultsByTarget[targetName];
            var buildResultItems = buildResult.Items;
            return buildResultItems.Select(item => item.ItemSpec);
        }
        return GetResultItems("ResolveProjectReferences")
            .Concat(GetResultItems("ResolveAssemblyReferences"));
    }
    // in Main2
    var references = GetReferences(@"C:\code\tmp\roslyn references\WebApplication2\WebApplication2.csproj");
    CSharpCompilation compilation = CreateCompilation(tree, references);
    // in CreateCompilation
    CSharpCompilation compilation =
        CSharpCompilation.Create("test")
            .WithOptions(options)
            .AddSyntaxTrees(tree)
            .AddReferences(references.Select(path => MetadataReference.CreateFromFile(path)));
