    private bool isStackPanelVisible;
    public bool IsStackPanelViesible
    {
        get { return isStackPanelVisible; }
        set 
        {
            isStackPanelVisible = value;
            //RaisePropertyChanged from your implementation of INotifyPropertyChanged
        }
    }
