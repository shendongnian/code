    // Activates when the mouse is down
    private bool drag = false;
    public void Grid_MouseDown(object sender, RoutedEventArgs e)
    {
        // activate the drag
        drag = true;
    }
    public void Grid_MouseUp(object sender, RoutedEventArgs e)
    {
        // deactivate the drag
        drag = false;
    }
    public void Grid_MouseMove(object sender, RoutedEventArgs e)
    {
        // check if the mouse is down
        if(drag)
        {
             // loop through each of your textblocks and change their width and text if necessary
            for(int i = 0; i < grid.Children.Count; i += 2)
            {
                 // access the textblock
                 TextBlock textblock = grid.Children[i];
                 // set the width to the width of the column it's in
                 textblock.Width = grid.ColumnDefinitions(Grid.GetColumn(textblock)).ActualWidth;
                 // if you want to change the font size...
                 textblock.FontSize = 12;
            }
        }
    }
