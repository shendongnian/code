    private int _selectedSourceParameterIndex; // Starts off as 0
    public int SelectedSourceParameterIndex
    {
        set
        {
            // Setting to zero would not change the value, and this will return
            if (_selectedSourceParameterIndex == value) return;
            //... nothing here gets executed ...
            _selectedSourceParameterIndex = value;
            RaisePropertyChanged(() => SelectedSourceParameterIndex);
            TargetParameters = model.CollectParameters(Categories[SelectedCategoryIndex].ID, new string[] { SourceParameters[SelectedSourceParameterIndex].StorageType });
        }
    }
