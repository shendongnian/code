	protected async void btnTest_Click(object sender, EventArgs e)
	{
		Task task1 = Task.Factory.StartNew(new Action(DoWork));
		// do other stuff
		await task1;
	}
