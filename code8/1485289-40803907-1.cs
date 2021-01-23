    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!closeCompleted)
        {
            e.Cancel = true;
        }
    }
