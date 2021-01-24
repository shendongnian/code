	EventHandler opengoogle = new EventHandler(delegate { System.Diagnostics.Process.Start("http://google.com"); });
	Stack<Control> Controls = new Stack<Control>();
	foreach (Control c in this.Controls) Controls.Push(c);
	do
	{
		Control c = Controls.Pop();
		if (c.Name.StartsWith("GooglePic"))
			c.Click += opengoogle;
		foreach (Control nc in c.Controls)
			Controls.Push(nc);
	} while (Controls.Count > 0);
