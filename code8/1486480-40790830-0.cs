        [STAThread]
        static void Main()
        {           
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionLog.SaveExceptionCloseApp(Program.RuntimeGUID, System.Reflection.MethodBase.GetCurrentMethod().Name + "()", e.Exception);
        }
