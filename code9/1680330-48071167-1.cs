        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            /// 
            
            [STAThread]
            static void Main()
            {
                var mutex = new Mutex(true, "Honda2MainForm", out var result);
                if (!result)
                {
                    MessageBox.Show("Phần mềm đang chạy!");
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Honda2MainForm());
                GC.KeepAlive(mutex);
            }
        }
