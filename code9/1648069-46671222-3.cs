    private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        List<DependencyObject> parents = new List<DependencyObject>();
        var parent = VisualTreeHelper.GetParent(sender as DependencyObject);
        while (parent != null)
        {
            parents.Add(parent);
            parent = VisualTreeHelper.GetParent(parent);
        }
        ;
    }
