     public partial class MainWindow: Window
    {
        public MainWindow( )
        {
            InitializeComponent( );
            // Iterate through all of the child elements
            // contained in the Grid control which I named "board".
            foreach( var control in board.Children.OfType<Button>( ) )
            {
                // Hook up the event handler of each button.
                control.Click += Button_Click;
            }
        }
        private void Button_Click( object sender, RoutedEventArgs e )
        {
            // Safe cast the sender to type Button.
            var button = sender as Button;
            if( button == null ) return;
            // Change the background color of the button
            // yellow or green based on which radio button
            // is checked.
            button.Background = playerOneRadioButton.IsChecked.Value ? Brushes.Green : Brushes.Yellow;
        }
    }
