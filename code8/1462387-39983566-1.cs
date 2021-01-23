    DependencyObject mainDep = new DependencyObject();
    private void ContextMenu_Click(object sender, RoutedEventArgs e)
    {
        DependencyObject dep = (DependencyObject)e.OriginalSource;
        while ((dep != null) && !(dep is Button))
        {
            dep = VisualTreeHelper.GetParent(dep);
        }
        mainDep = dep;
    }
    private void menuItem_Click(object sender, RoutedEventArgs e)
    {
        DependencyObject dep = mainDep;
        if (dep is Button)
        {
            Button btn = dep as Button;
            ...
               DO your stuff here
            ...
        }
    }
