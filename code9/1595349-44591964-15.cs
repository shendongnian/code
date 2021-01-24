    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (ActualWidth < 400)
        {
            //MainLayout.Orientation = Orientation.Vertical;
            //MainLayout.Columns = 1;
            Grid.SetColumn(RightPane, 0);
            Grid.SetRow(RightPane, 1);
        }
        else
        {
            //MainLayout.Orientation = Orientation.Horizontal;
            //MainLayout.Columns = 2;
            Grid.SetColumn(RightPane, 1);
            Grid.SetRow(RightPane, 0);
        }
    }
