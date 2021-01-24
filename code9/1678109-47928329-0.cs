    protected override void OnStartup(StartupEventArgs e)
    {
        Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        try
        {
            LoginForm loginForm = new LoginForm();
            bool result = (bool)loginForm.ShowDialog();
            if (result)
            {
                MessageBox.Show("I am here");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Closed += (ss, ee) => App.Current.Shutdown();
                mainWindow.Show();
            }
            else
            {
                App.Current.Shutdown();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
