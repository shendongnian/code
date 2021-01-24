    public class UnitTest1
    {
        private readonly List<Document> _documents;
        public UnitTest1()
        {
            var projPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "CodeFixDemoTests.csproj"));
            AnalyzerManager manager = new AnalyzerManager();
            ProjectAnalyzer analyzer = manager.GetProject(projPath);
            AdhocWorkspace workspace = analyzer.GetWorkspace();
            _documents = new List<Document>();
            foreach (var projectId in workspace.CurrentSolution.ProjectIds)
            {
                var project = workspace.CurrentSolution.GetProject(projectId);
                foreach (var documentId in project.DocumentIds)
                {
                    var document = workspace.CurrentSolution.GetDocument(documentId);
                    if (document.SupportsSyntaxTree)
                    {
                        _documents.Add(document);
                    }
                }
            }
        }
        public string _myField;
        [Fact]
        public void NoPublicFields()
        {
            var classes = _documents.Select(doc => new { doc, classes = doc.GetSyntaxRootAsync().Result.DescendantNodes().OfType<ClassDeclarationSyntax>() })
                .SelectMany(doc => doc.classes.Select(@class => new { @class, doc.doc }));
            foreach (var classDeclaration in classes)
            {
                var classFields = classDeclaration.@class.DescendantNodes().OfType<FieldDeclarationSyntax>();
                foreach (var field in classFields)
                {
                    var fieldHasPrivateModifier = field.Modifiers.Any(modifier => modifier.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.PrivateKeyword));
                    if (!fieldHasPrivateModifier)
                    {
                        var errorMessage = $"Public field in class: \"{classDeclaration.@class.Identifier}\", File: {classDeclaration.doc.FilePath}";
                        Assert.True(false, errorMessage);
                    }
                }
            }
        }
    }
