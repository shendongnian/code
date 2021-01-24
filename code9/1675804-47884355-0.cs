	public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
	{
        DTE.ExecuteCommand("View.QuickActions");
        System.Threading.Thread.Sleep(300);
        System.Windows.Forms.SendKeys.Send("{ENTER}");
    }
