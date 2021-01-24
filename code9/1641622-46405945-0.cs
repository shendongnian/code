    static class Program
    {
        static Form _main;
        static Form _previous;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // simulate some environment here
            _main = new Form1();
            _main.FormClosed += (s, e) => Application.Exit();
            _main.Show();
            new Form2 { Text = "1" }.Show();
            new Form2 { Text = "2" }.Show();
            new Form2 { Text = "3" }.Show();
            Application.Run();
        }
        public static void MenuOpen(Form form)
        {
            _main.Activate();
            _previous = form;
            _main.MainMenuStrip.MenuDeactivate += MainMenuStrip_MenuDeactivate;
            _main.MainMenuStrip.Show();
        }
        static void MainMenuStrip_MenuDeactivate(object sender, EventArgs e)
        {
            _main.MainMenuStrip.MenuDeactivate -= MainMenuStrip_MenuDeactivate;
            _previous.Activate();
            _previous.Focus();
        }
    }
