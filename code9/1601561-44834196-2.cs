    Workspace workspace;
    Workspace.TryGetWorkspace(location.SourceTree.GetText().Container, out workspace);
    if (workspace != null)
    {
        var invocMethodSymbol = model.GetSymbolInfo(ies.Expression).Symbol;
    	// Await this task if you can
        var declarationMethodSymbol = SymbolFinder.FindSourceDefinitionAsync(invocMethodSymbol, workspace.CurrentSolution).Result;
    }
