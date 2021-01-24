    FrameworkElement oldSetectedItem = null;
    private void myAdaptiveGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (oldSetectedItem != null)
            oldSetectedItem.Scale(1, 1, 50, 50, 500).Start();
        var container = myAdaptiveGridView.ContainerFromIndex(myAdaptiveGridView.SelectedIndex) as FrameworkElement;
        var listViewItemPresenter = VisualTreeHelper.GetChild(container, 0) as FrameworkElement;
        var outerGrid = VisualTreeHelper.GetChild(listViewItemPresenter, 0) as FrameworkElement;
        var grid = VisualTreeHelper.GetChild(outerGrid, 0) as FrameworkElement;
        oldSetectedItem = grid;
        grid.Scale(1.5f, 1.5f, 50, 50, 500).Start();
    }
