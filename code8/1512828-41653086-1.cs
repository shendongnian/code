        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyCustomApplicationContext());
        }
        private class MyCustomApplicationContext : ApplicationContext
        {
            public MyCustomApplicationContext()
            {
              var trayMenu = new ContextMenu();
              trayMenu.MenuItems.Add("Exit", OnExit);
              var notifyIcon = new NotifyIcon
              {
                  Text = @"Foo Bar",
                  ContextMenu = trayMenu,
                  Visible = true
              };
              var timer = new Timer {Interval = 20000};
              timer.Tick += DoStuff;
              timer.Start();
            }
     (...)
