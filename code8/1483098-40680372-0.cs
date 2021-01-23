    public ICommand SaveCommand
    {
        get
        {
            if (_saveCommand == null)
                _saveCommand = new RelayCommand(x => Save(), CanSave);
            return _saveCommand;
        }
    }
    private void CanSave(object sender)
    {
        // Validate properties, ensure viewmodel is in savable state.
        // Maybe you implemented IDataErrorInfo?
        if (Validator.TryValidateObject(this, new ValidationContext(this, null, null), new List<ValidationResult>(), true))
            return true;
        else
            return false;
    }
    private void Save()
    {
        // Database stuff, maybe WCF stuff, etc.
    }
