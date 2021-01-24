    private void MenuItem_ToolTipOpening(object sender, ToolTipEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        Point p = Mouse.GetPosition(element);
        if (p.X < 0 || p.X > element.ActualWidth || p.Y < 0 || p.Y > element.ActualHeight)
        {
            e.Handled = true;
        }
    }
