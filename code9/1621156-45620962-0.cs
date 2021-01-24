    static object instance = new object(); // HACK
    static SafeFileHandle hndl; // holds our filehandle (directory in this case)
    static void Main(string[] args)
    {
      
        // the folder to watch
        hndl = NativeMethods.CreateFile(@"c:\temp\delete", 1, 7, IntPtr.Zero, 3, 1107296256, new SafeFileHandle(IntPtr.Zero, false));
        // this selects IO completion threads in the ThreadPool
        ThreadPool.BindHandle(hndl);
        // this starts the actual listening
        Monitor(new byte[4096]);
        
        Console.ReadLine();
     
    }
