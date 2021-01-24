	[DllImport("sqlite3", EntryPoint = "sqlite3_open", CallingConvention=CallingConvention.Cdecl)]
	public static extern Result Open ([MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr db);
	[DllImport("sqlite3", EntryPoint = "sqlite3_open_v2", CallingConvention=CallingConvention.Cdecl)]
	public static extern Result Open ([MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr db, int flags, IntPtr zvfs);
	
	[DllImport("sqlite3", EntryPoint = "sqlite3_open_v2", CallingConvention = CallingConvention.Cdecl)]
	public static extern Result Open(byte[] filename, out IntPtr db, int flags, IntPtr zvfs);
	[DllImport("sqlite3", EntryPoint = "sqlite3_open16", CallingConvention = CallingConvention.Cdecl)]
	public static extern Result Open16([MarshalAs(UnmanagedType.LPWStr)] string filename, out IntPtr db);
	[DllImport("sqlite3", EntryPoint = "sqlite3_enable_load_extension", CallingConvention=CallingConvention.Cdecl)]
	public static extern Result EnableLoadExtension (IntPtr db, int onoff);
