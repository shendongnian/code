    public static class WinApi
    {
    	public static class KeyBoard
    	{
    		public enum VirtualKey
    		{
    			VK_LBUTTON = 0x01,
    			...
    			VK_RETURN = 0x0D
    		}
    	}
    
    
    	public static class Message
    	{
    		public enum MessageType : int
    		{
    			WM_KEYDOWN = 0x0100
    		}
    	
    		[DllImport("user32.dll")]
    		[return: MarshalAs(UnmanagedType.Bool)]
    		public static extern bool SendMessage(IntPtr hWnd, MessageType Msg, IntPtr wParam, IntPtr lParam);
    	}
    }
    
    private void timer2_Tick(object sender, EventArgs e)
    {
    	WinApi.Message.SendMessage(
    		hWnd: this.textBox.Handle, // Assuming that this handler is inside the same Form.
    		Msg: WinApi.Message.MessageType.WM_KEYDOWN,
    		wParam: new IntPtr((Int32)WinApi.KeyBoard.VirtualKey.VK_RETURN),
    		lParam: new IntPtr(1)); // Repeat once, but be careful - actual value is a more complex struct - https://msdn.microsoft.com/en-us/library/ms646280(VS.85).aspx
    }
