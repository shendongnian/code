    public class CustomRoslynHost : RoslynHost
    {   
        protected override Project CreateProject(Solution solution, DocumentCreationArgs args, CompilationOptions compilationOptions, Project previousProject = null)
        {
            var name = args.Name ?? "Program";
            var id = ProjectId.CreateNewId(name);
    
            var parseOptions = new CSharpParseOptions(kind: SourceCodeKind.Script, languageVersion: LanguageVersion.Latest);
    
            compilationOptions = compilationOptions.WithScriptClassName(name);
    
            solution = solution.AddProject(ProjectInfo.Create(
                id,
                VersionStamp.Create(),
                name,
                name,
                LanguageNames.CSharp,
                isSubmission: true,
                parseOptions: parseOptions,
                hostObjectType: typeof(MyContext),
                compilationOptions: compilationOptions,
                metadataReferences: previousProject != null ? ImmutableArray<MetadataReference>.Empty : DefaultReferences,
                projectReferences: previousProject != null ? new[] { new ProjectReference(previousProject.Id) } : null));
    
            var project = solution.GetProject(id);
    
            return project;
        }
    }
