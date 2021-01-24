    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!IsShuttingDown)
        {
            e.Cancel = true;
            ShowSplashWindow();
            PerformHeavyOperation();
            Application.Current.Shutdown();
            IsShuttingDown = true;
        }
    }
