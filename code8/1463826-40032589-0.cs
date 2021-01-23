	public void threadsTest(string[] urls)
	{
		var results = new Dictionary<string, string>();
		foreach (string mainURL in urls)
		{
			using (WebClient wc = new WebClient())
			{
				var pageHtml = wc.DownloadString(mainURL);
				results[mainUrl] = pageHtml;
			}
		}
		Invoke(new MethodInvoker(() => ProcessResults(results)));
	}
