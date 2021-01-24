	public void OnFocus(object sender, System.EventArgs e)
	{
		TabControl tc = (TabControl)sender;
		if (tc.SelectedTab == this.Parent)
		{
			//Parent-Tab is selected, do stuff...
		}
	}
