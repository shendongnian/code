    public partial class Service1 : ServiceBase{
    
      private FileSystemWatcher fileSystemWatcher;
	  private IntPtr deviceNotifyHandle;
	  private IntPtr deviceEventHandle;
	  private IntPtr directoryHandle;
	  private Win32.ServiceControlHandlerEx myCallback;
      public Service1()
      {
         InitializeComponent();
      }
    
      protected override void OnStart(string[] args)
      {
         base.OnStart(args);
         //
         RegisterDeviceNotification();
		fileSystemWatcher = new FileSystemWatcher();
		fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(fileSystemWatcher_Created);
		fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(fileSystemWatcher_Deleted);
		fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(fileSystemWatcher_Changed);
		fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(fileSystemWatcher_Renamed);
      }
    }
