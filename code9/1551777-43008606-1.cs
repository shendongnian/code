    private void OnFilterBoxLoaded(object sender, RoutedEventArgs e) {
        var tb = (TextBox)sender;
        // find column
        DataGridColumnHeader parent = null;
        DependencyObject current = tb;
        do {
            current = VisualTreeHelper.GetParent(current);
            parent = current as DataGridColumnHeader;
        }
        while (parent == null);
        // setup binding
        var binding = new Binding();
        // use parent column header as name of the filter property
        binding.Path = new PropertyPath("DataContext.Filter" + parent.Column.Header);
        binding.Source = this;
        binding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        tb.SetBinding(TextBox.TextProperty, binding);
    }
