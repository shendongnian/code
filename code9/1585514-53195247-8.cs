    void MyGridSizeChanged(object sender, SizeChangedEventArgs e) {
        if (sender is Grid myGrid) {
            var cellHeight = myGrid.RowDefinitions[Grid.GetRow(MyEllipse)].ActualHeight;
            var cellWidth  = myGrid.ColumnDefinitions[Grid.GetColumn(MyEllipse)].ActualWidth;
            var newSize    = Math.Min(cellHeight, cellWidth);
    
            MyEllipse.Height = newSize;
            MyEllipse.Width  = newSize;
        }
    }
