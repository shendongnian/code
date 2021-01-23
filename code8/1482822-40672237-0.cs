	private void Base_thd1()
	{
		BeginInvoke(new Action(() => list_Base.Items.Add("Start thd1")));
		Thread.Sleep(3000);
		BeginInvoke(new Action(() => list_Base.Items.Add("End thd1")));
		BeginInvoke(new Action(() => list_Base.Items.Add("Set ")));
		BeginInvoke(new Action(() => mre.Set()));
	}
