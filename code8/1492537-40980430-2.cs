	StaTaskScheduler Sta = new StaTaskScheduler(1);
	public void PrintHtml(string htmlPath)
	{
		Task.Factory.StartNew(() => PrintOnStaThread(htmlPath), CancellationToken.None, TaskCreationOptions.None, Sta).Wait();
	}
	void PrintOnStaThread(string htmlText)
	{
		const short PRINT_WAITFORCOMPLETION = 2;
		const int OLECMDID_PRINT = 6;
		const int OLECMDEXECOPT_DONTPROMPTUSER = 2;
		using (var browser = new WebBrowser())
		{
			browser.DocumentText = htmlText;
			while (browser.ReadyState != WebBrowserReadyState.Complete)
				Application.DoEvents();
			dynamic ie = browser.ActiveXInstance;
			ie.ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_DONTPROMPTUSER, PRINT_WAITFORCOMPLETION);
		}
	}
