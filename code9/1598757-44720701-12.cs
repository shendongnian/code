        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (e.NewSize.Width < MinWidht)
        {
            if (_grid)
            {
                _grid = false;
                Grid.Visibility = Visibility.Collapsed;
                var children = Grid.Children.ToList();
                Grid.Children.Clear();
                GridView.ItemsSource = children.ToList();
                GridView.Visibility = Visibility.Visible;
                Grid.Children.Clear();
            }
        }
        else
        {
            if (!_grid)
            {
                // change to GridView to Grid
            }
        }
    }
    private const double MinWidht = 700;
    private bool _grid = true;
