    private async void DisplaySomething_Click( object sender, RoutedEventArgs e )
    {
        if( string.IsNullOrWhiteSpace( City.Text ) ) {
            return;
        }
        
        // do some stuff
        
        Gr_Column0.Visibility = Visibility.Collapsed;
        CD_Column0.Width = new GridLength(0);
    }
