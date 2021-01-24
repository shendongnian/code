	[DllImport("user32.dll")]
	static extern uint RegisterWindowMessage(string lpString);
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
	private uint msgId = RegisterWindowMessage("notification");
	// Transmitter
	private void button1_Click(object sender, EventArgs e)
	{
		Process[] myInstances = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location));
		if (myInstances.Length == 0) return;
		foreach (Process instance in myInstances)
		{
			IntPtr handle = instance.MainWindowHandle;
			SendMessage(handle, (int)msgId, IntPtr.Zero, IntPtr.Zero);
		}            
	}
	// Receiver
	protected override void WndProc(ref Message msg)
	{
		if (msg.Msg == msgId) MessageBox.Show("well, notification is here now.");
		base.WndProc(ref msg);
	}
	
