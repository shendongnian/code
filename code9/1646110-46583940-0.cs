	[DllImport("user32.dll")]
	static extern uint RegisterWindowMessage(string lpString);
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, string lParam);
	private uint msgId = RegisterWindowMessage("my_message_type");
	// Transmitter
	private void Send(IntPtr targetWindowHandle, string msgText)
	{
		SendMessage(targetWindowHandle, (int)msgId, IntPtr.Zero, msgText);
	}
	// Receiver
	protected override void WndProc(ref Message msg)
	{
		if (msg.Msg == msgId)
		{
			string msgText = Marshal.PtrToStringAnsi(msg.LParam);
			MessageBox.Show(msgText);
		}
		base.WndProc(ref msg);
	}
