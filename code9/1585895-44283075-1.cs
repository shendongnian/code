    public sealed override async Task ComputeRefactoringsAsync(CodeRefactoringContext context)
    {
        // [...]
    
        context.RegisterRefactoring(CustomCodeAction.Create("MyAction",
    		(c, isPreview) => DoMyAction(context.Document, dec, c, isPreview)));
    }
    
    private static async Task<Solution> DoMyAction(Document document, MethodDeclarationSyntax method, CancellationToken cancellationToken, bool isPreview)
    {
        // some - for the question irrelevant - roslyn changes, like:
        // [...]
    
        // now the DTE magic
        if (!isPreview)
        {
            // [...]
        }
    
        return document.Project.Solution;
    }
