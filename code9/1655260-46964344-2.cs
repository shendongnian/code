	EventHandler openwebsite = new EventHandler(delegate { System.Diagnostics.Process.Start("website"); });
	foreach (Control c in this.Controls)
	{
		if(c.Name.StartsWith("CreditPic")) {
			c.Click += openwebsite;
		}
	}
