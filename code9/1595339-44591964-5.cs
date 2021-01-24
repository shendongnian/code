    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (ActualWidth < 400)
        {
           //MainLayout.Orientation = Orientation.Vertical;
           MainLayout.Columns = 1;
        }
        else
        {
            //MainLayout.Orientation = Orientation.Horizontal;
            MainLayout.Columns = 2;
        }
    }
