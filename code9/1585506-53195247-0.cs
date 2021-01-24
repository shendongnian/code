    void MyGridSizeChanged(Grid sender, SizeChangedEventArgs e) {
        var rowHeight    = sender.RowDefinitions[Grid.GetRow(MyEllipse)].ActualHeight;
        var columnWidth  = sender.ColumnDefinitions[Grid.GetColumn(MyEllipse)].ActualWidth;
        var newSize      = Math.Min(rowHeight, columnWidth);
        MyEllipse.Height = newSize;
        MyEllipse.Width  = newSize;
    }
