    private ScrollViewer getRootScrollViewer()
    {
        DependencyObject el = this;
        while (el != null && !(el is ScrollViewer))
        {
            el = VisualTreeHelper.GetParent(el);
        }
        return (ScrollViewer)el;
    }
    private void onPageLoaded(object sender, RoutedEventArgs e)
    {
        getRootScrollViewer().Focus(FocusState.Programmatic);
    }
