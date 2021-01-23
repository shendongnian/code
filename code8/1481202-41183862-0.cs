    var slnPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "MySolution.sln"));
    var workspace = MSBuildWorkspace.Create();
    _solution = workspace.OpenSolutionAsync(slnPath).Result;
    _project = _solution.Projects.First(p => p.Name == "MyProject");
    foreach (var documentId in _project.DocumentIds) {
        var document = _solution.GetDocument(documentId);
        if (document.SupportsSyntaxTree) {
            _documents.Add(document);
        }
    }
