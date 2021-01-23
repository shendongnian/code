    public sealed class SquareGrid : Grid
    {
        public SquareGrid()
        {
            this.Loaded += SquareGrid_Loaded;
        }
    
        private void SquareGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Height = this.ActualWidth;
        }
    }
