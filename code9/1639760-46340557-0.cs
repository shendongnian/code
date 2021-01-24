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
    
            static string xmlstr = @"
                <Windows ...> 
                <!-- ...  Omitted to save space ... --> 
                <Window/>
            ";
        }
    
        class MyApp
        {
            [STAThread]
            static void Main(string[] args)
            {
                Application app    = new Application();
                MySplash    splash = new MySplash();
                Window      win    = splash.CreateWindow();
                app.Run(win);
            }
        } //end-class
    } //end-namespace
