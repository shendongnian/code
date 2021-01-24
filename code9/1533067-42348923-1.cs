    private void DoSomethingButton_Click(object sender, RoutedEventArgs e)
    {
        List<string> selectedStrings = new List<string>();
        foreach (IEnumerable<string> array in outerListBox.Items.OfType<IEnumerable<string>>())
        {
            ListBoxItem lbi = outerListBox.ItemContainerGenerator.ContainerFromItem(array) as ListBoxItem;
            if (lbi != null)
            {
                ListBox innerListBox = GetChildOfType<ListBox>(lbi);
                if (innerListBox != null)
                {
                    foreach (string selectedString in innerListBox.SelectedItems.OfType<string>())
                        selectedStrings.Add(selectedString);
                }
            }
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
