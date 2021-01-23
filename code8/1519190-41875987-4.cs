    private StoredActionsModel _selectedStoredAction;
    public StoredActionsModel SelectedStoredAction
    {
        get { return _selectedStoredAction; }
        set
        {
            if (value != _selectedStoredAction)
            {
                //  Unset Selected on old value, if there was one
                if (_selectedStoredAction != null)
                {
                    _selectedStoredAction.Selected = false;
                }
                _selectedStoredAction = value;
                //  Set Selected on new value, if there is one
                if (_selectedStoredAction != null)
                {
                    _selectedStoredAction.Selected = true;
                }
                OnPropertyChanged("SelectedStoredAction");
            }
        }
    }
