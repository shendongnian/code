    private SelectableItemClass _SelectedSItem;
    public SelectableItemClass SelectedSItem
    {
        get { return _SelectedSItem; }
        set
        {
            if (previewItem == null)
                previewItem = new PreviewItemClass();
            previewItem.descr1 = "aaa";
            previewItem.descr2 = "bbb";
            RaisePropertyChanged("SelectedSItem");
        }
    }
