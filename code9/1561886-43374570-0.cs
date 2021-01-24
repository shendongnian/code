	for (int i = 0; i < 5; i++)
	{
		GMap.NET.WindowsForms.GMapControl control = new GMap.NET.WindowsForms.GMapControl();
		//...snip...
		control.OnTileLoadComplete += x => Control_OnTileLoadComplete(control, x);
	}
	private void Control_OnTileLoadComplete(object sender, long ElapsedMilliseconds)
	{
		// who has completed the loading?
        // the sender, that's who!
	}
