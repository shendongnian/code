    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    
    namespace Playlist
    {
        class Program
        {
    
            [DllImport("user32.dll")]
            private static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);
    
            private enum WindowShowStyle:uint
            {
                Hide = 0,
                ShowMinimized = 2, 
                Minimize = 6
            }
    
            static void Main(string[] args)
            {
                Run();
            }
            
           
            public static void Run()
            {
                       
                String username = Environment.UserName;
                username = char.ToUpper(username[0]) + username.Substring(1);
                Console.WriteLine("Hello " + username);
                Thread.Sleep(2000);
                Console.WriteLine("Opening Playlist...");
                Thread.Sleep(2000);
              
                Process.Start("wmplayer.exe", "C:\\Users\\" + username + "\\Music\\A_ChillstepMix.mp3");
                //Thread.Sleep(2000);
                //Console.WriteLine("Opening your IDE...");
                //Thread.Sleep(2000);
                //Process.Start("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\Common7\\IDE\\devenv.exe");
                Thread.Sleep(2000);
                Console.WriteLine("Minimizing Player...");
                Thread.Sleep(2000);
                MinimizePlayer();
                Thread.Sleep(2000);
                Console.WriteLine("Goodbye...");
                Thread.Sleep(5000);            
                System.Environment.Exit(0);   
    
            }       
            public static void MinimizePlayer()
            {
                Process[] ps = Process.GetProcesses();
                foreach(Process p in ps)
                {
                    if(p.ProcessName.Contains("wmplayer"))
                    {
                        IntPtr h = p.MainWindowHandle;
    
                        ShowWindow(h, WindowShowStyle.Minimize);
                    }
                }
            }
        }
    }
