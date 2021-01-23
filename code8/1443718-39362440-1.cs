	private ManualResetEvent serviceAvailableEvent = new ManualResetEvent(false);
	
	this.windowsService.ServiceAvailable += this.WindowsServiceAvailableEventHandler
	While (!CheckifServiceStarted()) 
	{
		DialogResult dlgResult = MessageBox.Show("Service is not Started.Please  start Service to continue", "Start Service", MessageBoxButtons.YesNo);
		if (dlgResult == DialogResult.Yes) 
			serviceAvailableEvent.WaitOne(10000);
		else 
			System.Environment.Exit(0);
	}
	private void DataServicesAvailableEventHandler(object sender, EventArgs e)
	{
		serviceAvailableEvent.Set();
	}
