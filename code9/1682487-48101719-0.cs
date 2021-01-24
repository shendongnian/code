    private void dataGrid_ScrollChanged(object sender, RoutedEventArgs e)
            {
                System.Windows.Controls.ScrollChangedEventArgs args = (System.Windows.Controls.ScrollChangedEventArgs)e;
                if (args.VerticalChange > 0)
                {
                    //scrolled down
                }
                else if (args.VerticalChange < 0)
                {
                    //scrolled up
                }
                else
                {
                    //who knows what happened
                    //probably just loading the grid
                }
    
            }
