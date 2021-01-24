	private void pageDelayTmr_Tick(object sender, EventArgs e)
	{
		FormEditLinks formEditLinks = new FormEditLinks();
		formEditLinks.Show();
		List<string> list = formEditLinks.GetData();
		if (list != null)
		{
			webBrowser1.Navigate(list[2]);
		}
		formEditLinks.Dispose();
	}
