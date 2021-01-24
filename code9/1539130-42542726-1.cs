    private void ListBox_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (var item in lb.Items)
        {
            var container = lb.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
            if (container != null)
            {
                //...
            }
        }
    }
