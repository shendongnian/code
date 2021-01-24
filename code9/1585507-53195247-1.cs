    void VisualizationSizeChanged(object sender, SizeChangedEventArgs e) {
        if (sender is Grid myGrid) {
            var rowHeight   = myGrid.RowDefinitions[Grid.GetRow(MyEllipse)].ActualHeight;
            var columnWidth = myGrid.ColumnDefinitions[Grid.GetColumn(MyEllipse)].ActualWidth;
            var newSize     = Math.Min(rowHeight, columnWidth);
    
            MyEllipse.Height = newSize;
            MyEllipse.Width  = newSize;
        }
    }
