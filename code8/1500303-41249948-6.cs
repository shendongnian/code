    private void Application_Startup(object sender, StartupEventArgs e)
    {
        try
        {
            if (new LoginWindow().ShowDialog() == true)
            {
                MessageBox.Show("login success I should keep executing my application..");
                new MainWindow().ShowDialog();
            }
            else
            {
                MessageBox.Show("login failed");
            }
        }
        finally
        {
            Shutdown();
        }
    }
