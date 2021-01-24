	const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.
	var oldValue = IntPtr.Zero;
	Process p = null;
	try
	{
		if (SafeNativeMethods.Wow64DisableWow64FsRedirection(ref oldValue))
		{
			var pinfo = new ProcessStartInfo(@"C:\Windows\System32\Narrator.exe")
			{
				CreateNoWindow = true,
				UseShellExecute = true,
				Verb = "runas"
			};
			p = Process.Start(pinfo);
		}
		// Do stuff.
		
		p.Close();
		
	}
	catch (Win32Exception ex)
	{
		// User canceled the UAC dialog.
		if (ex.NativeErrorCode != ERROR_CANCELLED)
			throw;
	}
	finally
	{
		SafeNativeMethods.Wow64RevertWow64FsRedirection(oldValue);
	}
    [System.Security.SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);
    }
