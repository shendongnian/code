	public Form1()
	{
		InitializeComponent();
		Pages.Add(page1);
		Pages.Add(page2);
		Pages.Add(page3);
		// change to first page
		ChangeToPage(0);
		SerialDataDriver.NewData += SerialDataDriver_NewData;
	}
	private void SerialDataDriver_NewData(string message)
	{
		if (this.InvokeRequired)
		{
			this.Invoke((MethodInvoker) delegate() {
				SerialDataDriver_NewData(message);
			});
		}
		else
		{
			// do something with "message"
			this.label1.Text = message;
		}
	}
