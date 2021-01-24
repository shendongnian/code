    private TDocument selectedItem;
    public TDocument SelectedItem
    {
        get
        {
            return selectedItem;
        }
        set
        {
            selectedItem?.YouAreNotSelected();
            value?.YouAreSelected();
            selectedItem = value;
            NotifyOfPropertyChange(() => SelectedItem);
        }
    }
