    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace lastActiveWindow
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                // New lines.. 
                SendKeys.SendWait("%{Tab}"); 
                Thread.Sleep(500);
                try
                {
                    // get the active window
                    var handle = GetForegroundWindow();
    
                    // Required ref: SHDocVw (Microsoft Internet Controls COM Object) - C:\Windows\system32\ShDocVw.dll
                    SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
    
                    // loop through all windows
                    foreach (SHDocVw.InternetExplorer window in shellWindows)
                    {
                        Console.WriteLine(((int) handle).ToString());
                        Console.WriteLine(window.HWND.ToString());
                        if (window.HWND == (int) handle)
                        {
                            // Required ref: Shell32 - C:\Windows\system32\Shell32.dll
                            var shellWindow = window.Document as Shell32.IShellFolderViewDual2;
    
                            // will be null if you are in Internet Explorer for example
                            if (shellWindow != null)
                            {
                                // Item without an index returns the current object
                                var currentFolder = shellWindow.Folder.Items().Item();
    
                                // special folder - use window title
                                // for some reason on "Desktop" gives null
                                if (currentFolder == null || currentFolder.Path.StartsWith("::"))
                                {
                                    // Get window title instead
                                    const int nChars = 256;
                                    var Buff = new StringBuilder(nChars);
                                    //if (GetWindowText(handle, Buff, nChars) > 0)
                                    //{
                                    //    return Buff.ToString();
                                    //}
                                }
                                else
                                {
                                    Directory.CreateDirectory(currentFolder.Path + "//NewFolder//Db_Scripts");
                                    Directory.CreateDirectory(currentFolder.Path + "//NewFolder//Documents");
                                    Directory.CreateDirectory(currentFolder.Path + "//NewFolder//SourceCode");
                                    // return currentFolder.Path;
                                }
                            }
    
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    Console.Read();
                }
                //Console.Read();
            }
    
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
    
            [DllImport("user32.dll")]
            private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        }
    }
