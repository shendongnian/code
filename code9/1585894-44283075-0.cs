    private readonly Func<CancellationToken, bool, Task<Solution>> _createChangedSolution;
    
    protected override async Task<IEnumerable<CodeActionOperation>> ComputePreviewOperationsAsync(CancellationToken cancellationToken)
    {
    	const bool isPreview = true;
    	// Content copied from http://source.roslyn.io/#Microsoft.CodeAnalysis.Workspaces/CodeActions/CodeAction.cs,81b0a0866b894b0e,references
    	var changedSolution = await GetChangedSolutionWithPreviewAsync(cancellationToken, isPreview).ConfigureAwait(false);
    	if (changedSolution == null)
    		return null;
    
    	return new CodeActionOperation[] { new ApplyChangesOperation(changedSolution) };
    }
    
    protected override Task<Solution> GetChangedSolutionAsync(CancellationToken cancellationToken)
    {
    	const bool isPreview = false;
    	return GetChangedSolutionWithPreviewAsync(cancellationToken, isPreview);
    }
    
    protected virtual Task<Solution> GetChangedSolutionWithPreviewAsync(CancellationToken cancellationToken, bool isPreview)
    {
    	return _createChangedSolution(cancellationToken, isPreview);
    }
