    private void listBoxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var items in listBoxItems.SelectedItems)
        {
            ListBoxItem lbi = listBoxItems.ItemContainerGenerator.ContainerFromItem(items) as ListBoxItem;
            if (lbi != null)
            {
                RadioButton rb = FindVisualChildren<RadioButton>(lbi).FirstOrDefault(x => x.IsChecked == true);
                if (rb != null)
                {
                    MessageBox.Show("selected: " + rb.Content.ToString());
                }
            }
        }
    }
    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            int NbChild = VisualTreeHelper.GetChildrenCount(depObj);
            for (int i = 0; i < NbChild; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
                foreach (T childNiv2 in FindVisualChildren<T>(child))
                {
                    yield return childNiv2;
                }
            }
        }
    }
