    DependencyObject mainDep = new DependencyObject();
    private void ContextMenu_Click(object sender, RoutedEventArgs e)
    {
        DependencyObject dep = (DependencyObject)e.OriginalSource;
        while ((dep != null) && !(dep is ListBoxItem))
        {
            dep = VisualTreeHelper.GetParent(dep);
        }
        mainDep = dep;
    }
    private void menuItem_Click(object sender, RoutedEventArgs e)
    {
        DependencyObject dep = mainDep;
        if (dep is ListBoxItem)
        {
            ...
               DO your stuff here
            ...
        }
    }
