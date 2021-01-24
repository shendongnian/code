    public ICommand ExpandedCommand
    {
        get { return _expandedCommand ?? (_saveToDatabaseCommand = new RelayCommand(TreeViewItemExpanded)); }
    }
    public void TreeViewItemExpanded()
    {
        // Add your code here. 
    }
