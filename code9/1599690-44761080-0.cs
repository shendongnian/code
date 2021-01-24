    private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
    {
        ItemContainerGenerator icg = sender as ItemContainerGenerator;
        if (icg.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
        {
            foreach (var item in icg.Items)
            {
                var container = icg.ContainerFromItem(item) as ListViewItem;
                Button button = FindVisualChild<Button>(container);
                if (button != null)
                {
                    button.Click -= Button_Click;
                    button.Click += Button_Click;
                }
            }
        }
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("clicked");
    }
    private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
    {
        for (int childCount = 0; childCount < VisualTreeHelper.GetChildrenCount(parent); childCount++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, childCount);
            if (child != null && child is T)
                return (T)child;
            else
            {
                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
        }
        return null;
    }
