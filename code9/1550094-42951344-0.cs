    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    const int SW_MAXIMIZE = 3;
    var process = new Process();
    process.StartInfo.FileName = ConfigurationManager.AppSettings["VLCPath"];
    process.Start();
    process.WaitForInputIdle();
    int count = 0;
    while (process.MainWindowHandle == IntPtr.Zero && count < 1000)
    {
        count++;
        Task.Delay(10);
    }
    if  (process.MainWindowHandle != IntPtr.Zero)
    { 
        ShowWindow(process.MainWindowHandle, SW_MAXIMIZE);
    }
