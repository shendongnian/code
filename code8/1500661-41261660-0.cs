    private void ClickEvent(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        Grid buttonGrid = button.Parent as Grid;
        if (buttonGrid != null)
        {
            Grid grid = buttonGrid.Parent as Grid;
            if (grid != null)
            {
                Grid editGrid = grid.Children.OfType<Grid>().FirstOrDefault(g => g.Name == "editGrid");
                if (editGrid != null)
                {
                    editGrid.Visibility = Visibility.Visible;
                }
            }
        }
    }
