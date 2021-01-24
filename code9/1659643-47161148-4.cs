    private void btnPause_Click(object sender, RoutedEventArgs e)
    {
        ManualResetEvent.Reset();
    }
    private void btnUnPause_Click(object sender, RoutedEventArgs e)
    {
        ManualResetEvent.Set();
    }
