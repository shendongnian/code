    private void onPageLoaded(object sender, RoutedEventArgs e)
    {
        var scrollViewer = gridView.ChildrenBreadthFirst().OfType<ScrollViewer>().First();
        scrollViewer.ViewChanged += onViewChanged;
    }
    private void onViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Scrolled");
    }
