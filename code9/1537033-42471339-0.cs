            var assemblies = new[]
            {
                Assembly.Load("Microsoft.CodeAnalysis"),
                Assembly.Load("Microsoft.CodeAnalysis.CSharp"),
                Assembly.Load("Microsoft.CodeAnalysis.Features"),
                Assembly.Load("Microsoft.CodeAnalysis.CSharp.Features"),
            };
            var partTypes = MefHostServices.DefaultAssemblies.Concat(assemblies)
                    .Distinct()
                    .SelectMany(x => x.GetTypes())
                    .ToArray();
            var compositionContext = new ContainerConfiguration()
                .WithParts(partTypes)
                .CreateContainer();
            var host = MefHostServices.Create(compositionContext);
            var workspace = new AdhocWorkspace(host);
            var document = workspace
                .AddProject("TestProject", LanguageNames.CSharp)
                .AddDocument("TestDocument.cs", "");
            var service = CompletionService.GetService(document);
