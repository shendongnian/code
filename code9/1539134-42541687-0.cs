    private void Expander_Expanded(object sender, RoutedEventArgs e)
    {
        var scrollViewer = GetNearestScrollViewerParent();
        if (scrollViewer == null)
            return;
        var expander = (Expander)sender;
        UIElement container = VisualTreeHelper.GetParent(expander) as UIElement;
        Point relativeLocation = expander.TranslatePoint(new Point(0, 0), container);
        scrollViewer.ScrollToVerticalOffset(relativeLocation.Y);
    }
    public ScrollViewer GetNearestScrollViewerParent()
    {
        for (var parent = VisualTreeHelper.GetParent(this); 
             parent != null; 
             parent = VisualTreeHelper.GetParent(parent))
        {
            if (parent is ScrollViewer)
                return parent as ScrollViewer;
        }
        return null;
    }
