	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
	{
		DTE.Find.FindWhat = @"Test";
		DTE.Find.Target = EnvDTE.vsFindTarget.vsFindTargetSolution;
		DTE.Find.Action = EnvDTE.vsFindAction.vsFindActionFindAll;
		DTE.Find.Backwards = false;
		DTE.Find.FilesOfType = @"";
		DTE.Find.KeepModifiedDocumentsOpen = false;
		DTE.Find.MatchCase = false;
		DTE.Find.MatchInHiddenText = true;
		DTE.Find.MatchWholeWord = false;
		DTE.Find.PatternSyntax = EnvDTE.vsFindPatternSyntax.vsFindPatternSyntaxLiteral;
		DTE.Find.ReplaceWith = @"";
		DTE.Find.ResultsLocation = EnvDTE.vsFindResultsLocation.vsFindResults1;
		DTE.Find.SearchSubfolders = true;
		DTE.Find.SearchPath = @"Entire Solution";
        DTE.Find.Execute();		
	}
