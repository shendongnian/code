    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (ActualWidth < 400)
        {
            MainLayout.Orientation = Orientation.Vertical;
        }
        else
        {
            MainLayout.Orientation = Orientation.Horizontal;
        }
    }
