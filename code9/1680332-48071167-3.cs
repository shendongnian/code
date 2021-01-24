        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            /// 
            
            [STAThread]
            static void Main()
            {
                var mutex = new Mutex(true, "MainForm", out var result);
                if (!result)
                {
                    MessageBox.Show("Running!");
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                GC.KeepAlive(mutex);
            }
        }
