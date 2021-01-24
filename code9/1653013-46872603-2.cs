    public ObservableCollection<TreeItem> SelectedItems()
    {
        ObservableCollection<TreeItem> toReturn = new ObservableCollection<TreeItem>();
        SelectedItems(toReturn);
        return toReturn;
    }
    private void SelectedItems(ObservableCollection<TreeItem> tempCollection)
    {
        if (nodeItems != null)
        {
            foreach (TreeItem item in nodeItems)
            {
                if (item.IsSelected == true)
                {
                    tempCollection.Add(item);
                }
            }
        }
        if (nodeChildren != null)
        {
            foreach (TreeNode node in nodeChildren)
            {
                node.SelectedItems(tempCollection);
            }
        }
    }
