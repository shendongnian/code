    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread t = new Thread(new ThreadStart(splash));
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            Application.Run(new Form1());
        }
        private static void splash()
        {
            Application.Run(new Form2());
        }
    }
