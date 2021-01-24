        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView tv = e.Source as TreeView;
            TreeViewItem tvi = tv.ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;
        }
