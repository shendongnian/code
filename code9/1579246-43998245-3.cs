    public ICommand ExpandedCommand
    {
        get { return _expandedCommand ?? (_expandedCommand = new RelayCommand(TreeViewItemExpanded)); }
    }
    public void TreeViewItemExpanded()
    {
        // Add your code here. 
    }
