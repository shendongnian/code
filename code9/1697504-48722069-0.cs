	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
	{
        int options = (int)(EnvDTE.vsFindOptions.vsFindOptionsRegularExpression |
               EnvDTE.vsFindOptions.vsFindOptionsMatchCase |
               EnvDTE.vsFindOptions.vsFindOptionsMatchInHiddenText |
               EnvDTE.vsFindOptions.vsFindOptionsSearchSubfolders |
               EnvDTE.vsFindOptions.vsFindOptionsKeepModifiedDocumentsOpen);
        DTE.Find.FindReplace(EnvDTE.vsFindAction.vsFindActionReplaceAll,
            @"(\.Register\w*)\(""([^""]+)""",
            options,
            @"$1(nameof($2)",
            EnvDTE.vsFindTarget.vsFindTargetCurrentDocument);
    }
