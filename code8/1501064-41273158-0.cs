    Border border = (Border)sender;
    Grid grid = border.Child as Grid;
    if (grid != null)
    {
        Button button = grid.Children[0] as Button;
        if(button != null)
           button.Visibility = Visibility.Visible;
    }
