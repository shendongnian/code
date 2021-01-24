        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin frmLogin = new FrmLogin();
            UserInfo userInfo = frmLogin.Login();
            if (userInfo != null)
            {
                // open main form with current user
                Application.Run(new MainForm(userInfo));
            }
        }
