    protected void OnClick(object sender, EventArgs e)
	{
		foreach (ListItem item in cb1.Items)
		{
			var result = bool.Parse(item.Value);    
			System.Diagnostics.Debug.WriteLine(result);            
		}
	}
