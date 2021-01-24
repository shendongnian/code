    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows;
    using GlobalHotKey;
    using System.Windows.Input;
    using System.Timers;
    using System.Threading.Tasks;
    using Microsoft.Win32;
    using FullScreenShot.Properties;
    
    namespace FullScreenShot
    {
        class Program
        {
            private static NotifyIcon notifyIcon;
            private static HotKeyManager hotKeyManager;
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                // We need to dispose here, or the icon will not remove until the 
                // system tray is updated.
                System.Windows.Forms.Application.ApplicationExit += delegate { notifyIcon.Dispose(); };
                CreateNotifyIcon();
                System.Windows.Forms.Application.Run();
            }
    
            /// <summary>
            /// Creates the icon that sits in the system tray.
            /// </summary>
    
            private static void CreateNotifyIcon()
            {
                notifyIcon = new NotifyIcon
                {
                    Icon = Resources.AppIcon,
                    ContextMenu = GetContextMenu()
                };
                notifyIcon.Visible = true;
                /*------------------------------------------------------------*/
                hotKeyManager = new HotKeyManager();//Creates Hotkey manager from GlobalHotKey
    
                var hotKey = hotKeyManager.Register(Key.F12, ModifierKeys.Control); // Sets Hotkey to Control + F12, ModifierKeys must be pressed first/
    
                hotKeyManager.KeyPressed += HotKeyManagerPressed; //Creates void for "HotKeyManagerPressed"
    
               
    
        }
          private static void HotKeyManagerPressed(object sender, KeyPressedEventArgs e) //Checks to see if hotkey is pressed
            {
                if (e.HotKey.Key == Key.F12)
    
                {
                    TakeFullScreenShotAsync();
                    BalloonTip();
                    // MessageBox.Show("Screenshot Taken");
                }
            }
            /// <summary>
            /// Creates BalloonTip to notify you that your Screenshot was taken.
            /// </summary>
            private static void BalloonTip()
            {
                notifyIcon.Visible = true;
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.ShowBalloonTip(740, "Important From Screenshot", "Screenshot Taken", ToolTipIcon.Info);
            }
    
            private static void BalloonTip2()
            {
                notifyIcon.Visible = true;
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.ShowBalloonTip(1, "Important From Screenshot", "Screenshot will now begin on startup", ToolTipIcon.Info);
            }
    
            ///<summary>
            ///Creates the contextmenu for the Icon
            ///<summary>
            private static ContextMenu GetContextMenu()
            {
                string myPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = myPath;
                ContextMenu menu = new ContextMenu();
                menu.MenuItems.Add("Take Screenshot (Ctrl+F12)", delegate { TakeFullScreenShotAsync(); });
                menu.MenuItems.Add("Open Folder", delegate { prc.Start(); });
                menu.MenuItems.Add("Exit", delegate { System.Windows.Forms.Application.Exit(); });
                menu.MenuItems.Add("Run On Startup", delegate { RunOnStartup(); });
    
                return menu;
    
            }
    
            /// <summary>
            /// Simple function that finds Registry and adds the Application to the startup
            /// </summary>
            private static void RunOnStartup()
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                reg.SetValue("MyApp", Application.ExecutablePath.ToString());
                BalloonTip2();
                MessageBox.Show("The Program will now start on startup");
            }
    
    
            /// <summary>
            /// Gets points for the screen uses those points to build a bitmap of the screen and saves it.
            /// </summary>
            private static async void TakeFullScreenShotAsync()
            {
                await Task.Delay(750);//Allows task to be waited on for .75ths of a second. Time In ms.
    
    
                int width = Screen.PrimaryScreen.Bounds.Width;
                int height = Screen.PrimaryScreen.Bounds.Height;
    
                using (Bitmap screenshot = new Bitmap(width, height, PixelFormat.Format32bppArgb))
                {
                    using (Graphics graphics = Graphics.FromImage(screenshot))
                    {
                        System.Drawing.Point origin = new System.Drawing.Point(0, 0);
                        System.Drawing.Size screenSize = Screen.PrimaryScreen.Bounds.Size;
                        //Copy Entire screen to entire bitmap.
                        graphics.CopyFromScreen(origin, origin, screenSize);
                    }
    
                    //Check to see if the file exists, if it does, append.
                    int append = 1;
    
                    while (File.Exists($"Screenshot{append}.jpg"))
                        append++;
    
                    string fileName = $"Screenshot{append}.jpg";
                    screenshot.Save(fileName, ImageFormat.Jpeg);
                }
            }
        }
    }
