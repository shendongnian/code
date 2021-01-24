	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
	{
        DTE.ExecuteCommand("Edit.LineDown");
        DTE.ExecuteCommand("Edit.Paste");
    }
