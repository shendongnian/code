    private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
    {
        TreeViewItem selectedNode = (TreeViewItem)treeView.SelectedItem;
        MessageBox.Show(selectedNode.Header.ToString());
    }
