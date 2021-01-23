    private void Grid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (!e.Handled)
        {
            Decorator border = VisualTreeHelper.GetChild(listview1, 0) as Decorator;
            ScrollViewer sv = border.Child as ScrollViewer;
            var arg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta) { RoutedEvent = UIElement.MouseWheelEvent, Source = sender };
            sv.RaiseEvent(arg);
        }
    }
