    private void listViewDirectory_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var container = AllDevicesGridView.ContainerFromItem(AllDevicesGridView.Items[1]);
        GridViewItem item = container as GridViewItem;
        ListViewItemPresenter itempresenter;
        IEnumerable<ListViewItemPresenter> items = FindVisualChildren<ListViewItemPresenter>(item);
        int count = items.Count();
        itempresenter = items.ElementAt<ListViewItemPresenter>(0);           
        itempresenter.DataContext = new Person() { Name = "update", Contact = "update" };
    }
    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
                foreach (T childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
