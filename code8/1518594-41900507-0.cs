    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Threading;
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static void Main()
        {
            Process[] procs = Process.GetProcessesByName("chrome");
            if (procs.Length == 0)
            {
                Console.WriteLine("Google Chrome is not currently open");
                return;
            }
            List<string> titles = new List<string>();
            IntPtr hWnd = IntPtr.Zero;
            int id = 0;
            int numTabs = procs.Length;
            foreach (Process p in procs)
            {
                if (p.MainWindowTitle.Length > 0)
                {
                    hWnd = p.MainWindowHandle;
                    id = p.Id;
                    break;
                }
            }
            bool isMinimized = IsIconic(hWnd);
            if (isMinimized)
            {
                ShowWindow(hWnd, 9); // restore
                Thread.Sleep(100);
            }
            SetForegroundWindow(hWnd);
            SendKeys.SendWait("^1"); // change focus to first tab
            Thread.Sleep(100);
            int next = 1;
            string title;
            while (next <= numTabs)
            {
                try
                {
                    title = Process.GetProcessById(id).MainWindowTitle.Replace(" - Google Chrome", "");
                    if (title.ToLower().Contains("youtube"))
                    {
                        SendKeys.SendWait("^{w}"); // close tab.
                        Thread.Sleep(100);
                    }
                    next++;
                    SendKeys.SendWait("^{TAB}"); // change focus to next tab
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    // Chrome internal process, doesn't have tab.
                    
                }               
            }
            if (isMinimized)
            {
                ShowWindow(hWnd, 6); // minimize again
                Thread.Sleep(100);
            }
            hWnd = Process.GetCurrentProcess().MainWindowHandle;
            SetForegroundWindow(hWnd);
            Thread.Sleep(100);
            Console.WriteLine("Closed youtube tabs");
            Console.ReadKey();
        }
    }
