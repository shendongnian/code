    private int ControlHandler(int control, int eventType, IntPtr eventData, IntPtr context)
    {
          if (control == Win32.SERVICE_CONTROL_STOP || control == Win32.SERVICE_CONTROL_SHUTDOWN)
          {
            UnregisterHandles();
            Win32.UnregisterDeviceNotification(deviceEventHandle);
            base.Stop();
          }
          else if (control == Win32.SERVICE_CONTROL_DEVICEEVENT)
          {
            string c;
            switch (eventType)
            {
              case Win32.DBT_DEVICEARRIVAL:
               //This is an example ... I do not use the DBT_DEVICEARRIVAL event, but it can be used. Instead use the ManagementEventWatcher class to detect when a device arrives and driveLetter.
                  RegisterForHandle(driveLetter);
			      fileSystemWatcher.Path = driveLetter + ":\\";
			      fileSystemWatcher.EnableRaisingEvents = true;
                 break;
              case Win32.DBT_DEVICEQUERYREMOVE:
    
                  Win32.DEV_BROADCAST_HDR hdrR;
                  Win32.DEV_BROADCAST_HANDLE dbhdl;
                  hdrR = (Win32.DEV_BROADCAST_HDR)
                  Marshal.PtrToStructure(eventData, typeof(Win32.DEV_BROADCAST_HDR));
    
                  if (hdrR.dbcc_devicetype == Win32.DBT_DEVTYP_HANDLE)
                  {
                    dbhdl = (Win32.DEV_BROADCAST_HANDLE)
                    Marshal.PtrToStructure(eventData, typeof(Win32.DEV_BROADCAST_HANDLE));
    
                    UnregisterHandles();
                    fileSystemWatcher.EnableRaisingEvents = false;
                    fileSystemWatcher = null;
                  }
    
                  break;
             }
           }
    
             return 0;
            }
    private void UnregisterHandles()
    {
    	if (directoryHandle != IntPtr.Zero)
    	{
    		Win32.CloseHandle(directoryHandle);
    		directoryHandle = IntPtr.Zero;
    	}
    	if (deviceNotifyHandle != IntPtr.Zero)
    	{
    		Win32.UnregisterDeviceNotification(deviceNotifyHandle);
    		deviceNotifyHandle = IntPtr.Zero;
    	}
    }
    private void RegisterForHandle(char c)
    {
    	Win32.DEV_BROADCAST_HANDLE deviceHandle = new Win32.DEV_BROADCAST_HANDLE();
    	int size = Marshal.SizeOf(deviceHandle);
    	deviceHandle.dbch_size = size;
    	deviceHandle.dbch_devicetype = Win32.DBT_DEVTYP_HANDLE;
    	directoryHandle = CreateFileHandle(c + ":\\");
    	deviceHandle.dbch_handle = directoryHandle;
    	IntPtr buffer = Marshal.AllocHGlobal(size);
    	Marshal.StructureToPtr(deviceHandle, buffer, true);
    	deviceNotifyHandle = Win32.RegisterDeviceNotification(this.ServiceHandle, buffer, Win32.DEVICE_NOTIFY_SERVICE_HANDLE);
    	if (deviceNotifyHandle == IntPtr.Zero)
    	{
    		// TODO handle error
    	}
    }
    public static IntPtr CreateFileHandle(string driveLetter)
    {
    	// open the existing file for reading          
    	IntPtr handle = Win32.CreateFile(
    			driveLetter,
    			Win32.GENERIC_READ,
    			Win32.FILE_SHARE_READ | Win32.FILE_SHARE_WRITE,
    			0,
    			Win32.OPEN_EXISTING,
    			Win32.FILE_FLAG_BACKUP_SEMANTICS | Win32.FILE_ATTRIBUTE_NORMAL,
    			0);
    
    	if (handle == Win32.INVALID_HANDLE_VALUE)
    	{
    		return IntPtr.Zero;
    	}
    	else
    	{
    		return handle;
    	}
    }
   
    public class Win32
    {
    	public const int DEVICE_NOTIFY_SERVICE_HANDLE = 1;
    	public const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;
    
    	public const int SERVICE_CONTROL_STOP = 1;
    	public const int SERVICE_CONTROL_DEVICEEVENT = 11;
    	public const int SERVICE_CONTROL_SHUTDOWN = 5;
    
    	public const uint GENERIC_READ = 0x80000000;
    	public const uint OPEN_EXISTING = 3;
    	public const uint FILE_SHARE_READ = 1;
    	public const uint FILE_SHARE_WRITE = 2;
    	public const uint FILE_SHARE_DELETE = 4;
    	public const uint FILE_ATTRIBUTE_NORMAL = 128;
    	public const uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
    	public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
    
    	public const int DBT_DEVTYP_DEVICEINTERFACE = 5;
    	public const int DBT_DEVTYP_HANDLE = 6;
    
    	public const int DBT_DEVICEARRIVAL = 0x8000;
    	public const int DBT_DEVICEQUERYREMOVE = 0x8001;
    	public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
    
    	public const int WM_DEVICECHANGE = 0x219;
    
    	public delegate int ServiceControlHandlerEx(int control, int eventType, IntPtr eventData, IntPtr context);
    
    	[DllImport("advapi32.dll", SetLastError = true)]
    	public static extern IntPtr RegisterServiceCtrlHandlerEx(string lpServiceName, ServiceControlHandlerEx cbex, IntPtr context);
    
    	[DllImport("kernel32.dll", SetLastError = true)]
    	[return: MarshalAs(UnmanagedType.Bool)]
    	public static extern bool GetVolumePathNamesForVolumeNameW(
    			[MarshalAs(UnmanagedType.LPWStr)]
    				string lpszVolumeName,
    			[MarshalAs(UnmanagedType.LPWStr)]
    				string lpszVolumePathNames,
    			uint cchBuferLength,
    			ref UInt32 lpcchReturnLength);
    
    	[DllImport("kernel32.dll")]
    	public static extern bool GetVolumeNameForVolumeMountPoint(string
    		lpszVolumeMountPoint, [Out] StringBuilder lpszVolumeName,
    		uint cchBufferLength);
    
    	[DllImport("user32.dll", SetLastError = true)]
    	public static extern IntPtr RegisterDeviceNotification(IntPtr IntPtr, IntPtr NotificationFilter, Int32 Flags);
    
    	[DllImport("user32.dll", CharSet = CharSet.Auto)]
    	public static extern uint UnregisterDeviceNotification(IntPtr hHandle);
    
    	[DllImport("kernel32.dll", SetLastError = true)]
    	public static extern IntPtr CreateFile(
    			string FileName,                    // file name
    			uint DesiredAccess,                 // access mode
    			uint ShareMode,                     // share mode
    			uint SecurityAttributes,            // Security Attributes
    			uint CreationDisposition,           // how to create
    			uint FlagsAndAttributes,            // file attributes
    			int hTemplateFile                   // handle to template file
    			);
    
    	[DllImport("kernel32.dll", SetLastError = true)]
    	public static extern bool CloseHandle(IntPtr hObject);
    
    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    	public struct DEV_BROADCAST_DEVICEINTERFACE
    	{
    		public int dbcc_size;
    		public int dbcc_devicetype;
    		public int dbcc_reserved;
    		[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
    		public byte[] dbcc_classguid;
    		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    		public char[] dbcc_name;
    	}
    
    	[StructLayout(LayoutKind.Sequential)]
    	public struct DEV_BROADCAST_HDR
    	{
    		public int dbcc_size;
    		public int dbcc_devicetype;
    		public int dbcc_reserved;
    	}
    
    	[StructLayout(LayoutKind.Sequential)]
    	public struct DEV_BROADCAST_HANDLE
    	{
    		public int dbch_size;
    		public int dbch_devicetype;
    		public int dbch_reserved;
    		public IntPtr dbch_handle;
    		public IntPtr dbch_hdevnotify;
    		public Guid dbch_eventguid;
    		public long dbch_nameoffset;
    		public byte dbch_data;
    		public byte dbch_data1;
    	}
    }
