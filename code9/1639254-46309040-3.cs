    private void OnNestedItemsLVGotFocus(object sender, RoutedEventArgs e)
    {
        var viewModel = this.DataContext as MainWindowViewModel;
        var parentItem = (sender as FrameworkElement)?.DataContext as TopItem;
        if (viewModel != null && parentItem != null)
            viewModel.SelectedItem = parentItem;
    }
