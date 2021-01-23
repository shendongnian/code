    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        int col = Grid.GetColumn((Button)sender);
        int row = Grid.GetRow((Button)sender);
        Button source = e.Source as Button;
        source.Visibility = Visibility.Hidden;
        for (int i = 0; i < Grid.Children.Count; i++) {
            Button childButton = Grid.Children[i] as Button;
            if(childButton == null) continue;
            int childCol = Grid.GetColumn(childButton);
            int childRow= Grid.GetRow(childButton);
            if(Math.Abs(childCol - col) < 2 && Math.Abs(childRow - row) < 2) childButton.Visibility = Visibility.Hidden;
        }
    }
