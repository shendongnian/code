    private void Button_Click(object sender, RoutedEventArgs e)
    {
        sp.Visibility = Visibility.Visible;
        Dispatcher.BeginInvoke(new Action(() =>
        {
            ScrollToRight(txtImagesFolder);
            ScrollToRight(txtTextFolder);
        }), System.Windows.Threading.DispatcherPriority.Background);
    }
