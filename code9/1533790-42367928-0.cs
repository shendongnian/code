	static class Native
	{
		[DllImport(ExternDll.USER32, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PostMessage(
			IntPtr hWnd,
			uint Msg,
			IntPtr wParam,
			IntPtr lParam);
		
		[DllImport(ExternDll.USER32, CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern uint RegisterWindowMessage(
			string lpString);
		
		const uint HWND_BROADCAST = 0xFFFFU;
	}
		
	static class Program 
	{
		public static uint _id;
		
		static void Main()
		{
			_id = Native.RegisterWindowMessage("Something_ShowInstance");
		
			if (_id == 0U)
			{
				Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
			}
		
			if (SingleInstanceMutex.WaitOne(TimeSpan.Zero, true))
			{
				// ...
			}
			else
			{
				Native.PostMessage(
					(IntPtr)HWND_BROADCAST,
					_id,
					IntPtr.Zero,
					IntPtr.Zero));
			}
		}
	}
