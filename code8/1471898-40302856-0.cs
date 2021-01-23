        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
    
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
    
            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show(args.Exception.Message, "ThreadException");
            };
    
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                MessageBox.Show(args.ExceptionObject.ToString(), "UnhandledException");
            };
    
            try
            {
                Application.Run(new Form1());
            }
    
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Application.Run() exception");
            }
        }
        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            throw e.Exception;
        }
