    // FILE: splashy.cs
    using System;
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Windows;
    using System.Windows.Markup;
    using System.Threading;
    namespace Splashy
    {
        class MySplash
        {
            Window win;
    
            public Window CreateWindow()
            {
                var mem     = new MemoryStream(
                                  ASCIIEncoding.UTF8.GetBytes(xmlstr));
                win         = (Window)XamlReader.Load(mem);
                (new Thread(CloseIt)).Start();
                return win;
            }
    
            public void CloseIt() {
                Thread.Sleep(2000);
                Application.Current.Dispatcher.Invoke(() => {
                    win.Close();
                });
            }
            [STAThread]
            static void Main(string[] args)
            {
                Application app    = new Application();
                MySplash    splash = new MySplash();
                Window      win    = splash.CreateWindow();
                app.Run(win);
            }
    
            static string xmlstr = @"
                <Windows ...> 
                <!-- ...  Omitted to save space ... --> 
                <Window/>
            ";
        } //end-class
    } //end-namespace
