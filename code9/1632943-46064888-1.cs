    private ListItem selectedList;
    public ListItem SelectedList {
        get {
            return selectedList;
        }
        set {
            if (selectedList != value) {
                var oldValue = selectedList;
                selectedList = value;
                OnListSelected(this, EventArgs.Empty);
            }
        }
    }
