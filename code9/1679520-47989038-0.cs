    private void MyPage_Loaded(object sender, RoutedEventArgs e)
    {
        Grid myGrid = (Grid)this.FindName("GridItem");
        this.Content = null;
        Grid ViewGrid = new Grid() { Background = new SolidColorBrush(Colors.LightBlue) };
        ViewGrid.Children.Add(myGrid);
        this.Content = ViewGrid;
    }
