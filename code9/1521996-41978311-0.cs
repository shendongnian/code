    private void btnOK_Click(object sender, RoutedEventArgs e)
    {
        if (dispatcherTimer != null)
        {
            dispatcherTimer.Tick -= dispatcherTimer_Tick;
            dispatcherTimer.Stop();
        }
        Window.GetWindow(this).Close();
    }
