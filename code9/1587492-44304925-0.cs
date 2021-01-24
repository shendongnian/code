    private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
    {
        TreeViewItem item = e.OriginalSource as TreeViewItem;
        if (item != null)
        {
            TreeViewItem child = GetChildOfType<TreeViewItem>(item);
            if (child != null && child.Tag != null)
                MessageBox.Show(child.Tag.ToString());
        }
    }
    private static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj == null)
            return null;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
            var result = (child as T) ?? GetChildOfType<T>(child);
            if (result != null)
                return result;
        }
        return null;
    }
